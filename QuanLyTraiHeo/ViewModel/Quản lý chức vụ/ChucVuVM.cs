using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiveCharts.Defaults;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows.Quản_lý_chức_vụ;
using QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên;

namespace QuanLyTraiHeo.ViewModel
{
    public class ChucVuVM : BaseViewModel
    {
        public ObservableCollection<CHUCVU> listChucVu { get; set; }
        public ObservableCollection<PERMISION> listPermission { get; set; }
        public int listviewSelectedIndex { get; set; }

        public ObservableCollection<PermissionModel> permissionModels { get; set; }
        public PERMISION selectedPermission { get; set; }
        public PERMISION ModifyPermission { get; set; }
        public CHUCVU selectedChucVu { get; set; }
        public CHUCVU newChucVu { get; set; }
        public string textTimKiem { get; set; }
        public string PermissionName { get; set; }
        public ICommand themCommand { get; set; }
        public ICommand TextTimKiemChangeCommand { get; set; }
        public ICommand ChinhSuaPermissionCommand { get; set; }
        public ICommand permissionSelectionchanged { get; set; }
        public ICommand EditCommand { get; set; }

        public ChucVuVM()
        {

            textTimKiem = "";
            listChucVu = new ObservableCollection<CHUCVU>();
            listPermission = new ObservableCollection<PERMISION>();
            selectedChucVu = new CHUCVU();
            newChucVu = new CHUCVU();
            selectedPermission = new PERMISION();
            ModifyPermission = new PERMISION();


            themCommand = new RelayCommand<Grid>((p) => { return true; }, p => { ThemChucVu(); });
            EditCommand = new RelayCommand<Window>((p) => { return true; }, p => { Edit(p); });
            ChinhSuaPermissionCommand = new RelayCommand<Button>((p) => { return true; }, p => { ChinhSuaPermission(); });
            permissionSelectionchanged = new RelayCommand<Button>((p) => { return true; }, p => { PermissionSelectionChanged(); });


            TextTimKiemChangeCommand = new RelayCommand<ListView>((p) => { return true; }, p => {
                LoadListChucVu();
            });
            LoadListPermission();
            LoadListChucVu();
            permissionModels = new ObservableCollection<PermissionModel>();
            permissionModels.Add(new PermissionModel(false,"QuanLyNhanVien",1));
            permissionModels.Add(new PermissionModel(false, "QuanLyDanHeo",2));
            permissionModels.Add(new PermissionModel(false, "QuanLyKho",3));
            permissionModels.Add(new PermissionModel(false, "QuanLyTaiChinh",4));
            permissionModels.Add(new PermissionModel(false, "QuanLyCayMucTieu",5));
            permissionModels.Add(new PermissionModel(false, "QuanlyNhatKy",6));

        }

        private void ChinhSuaPermission()
        {
            if (PermissionName == String.Empty)
            {
                MessageBox.Show("Vui lòng điền tên chức vụ!");
                return;
                    }
                    if(ModifyPermission == null)
            {

                ModifyPermission = new PERMISION();
                ModifyPermission.ID_Permision = "Per"+ listPermission.Count.ToString();
                ModifyPermission.Name_Permision = PermissionName;
                DataProvider.Ins.DB.PERMISIONs.Add(ModifyPermission);
            }
            else if(ModifyPermission.Name_Permision != PermissionName)
            {

                ModifyPermission = new PERMISION();
                ModifyPermission.ID_Permision = "Per" + listPermission.Count.ToString();
                ModifyPermission.Name_Permision = PermissionName;
                DataProvider.Ins.DB.PERMISIONs.Add(ModifyPermission);

            }

            DataProvider.Ins.DB.SaveChanges();


            DataProvider.Ins.DB.PERMISION_DETAIL.RemoveRange(DataProvider.Ins.DB.PERMISION_DETAIL.Where(x => x.ID_Permision == ModifyPermission.ID_Permision));
            DataProvider.Ins.DB.SaveChanges();


            foreach (var item in permissionModels)
                if(item.isSelected)
                {
                    PERMISION_DETAIL pERMISION_DETAIL = new PERMISION_DETAIL();
                    pERMISION_DETAIL.ID_PermisionDetail = ("PD" + ModifyPermission.ID_Permision + item.number.ToString()).ToString().Replace(" ","");
                    pERMISION_DETAIL.ActionDetail = item.ActionDetail;
                    pERMISION_DETAIL.ID_Permision = ModifyPermission.ID_Permision;
                    MessageBox.Show(pERMISION_DETAIL.ID_PermisionDetail);
                    DataProvider.Ins.DB.PERMISION_DETAIL.Add(pERMISION_DETAIL);
                }

            DataProvider.Ins.DB.SaveChanges();
            LoadListPermission();

        }
        private void LoadListChucVu()
        {
            listChucVu.Clear();

            var list = DataProvider.Ins.DB.CHUCVUs.Where(s => s.TenChucVu.Contains(textTimKiem) ).ToList();
            foreach (var items in list)
                listChucVu.Add(items);
          
        }
        private void PermissionSelectionChanged()
        {
            if (ModifyPermission == null)
                return;
permissionModels.Clear();
            permissionModels.Add(new PermissionModel(false, "QuanLyNhanVien", 1));
            permissionModels.Add(new PermissionModel(false, "QuanLyDanHeo", 2));
            permissionModels.Add(new PermissionModel(false, "QuanLyKho", 3));
            permissionModels.Add(new PermissionModel(false, "QuanLyTaiChinh", 4));
            permissionModels.Add(new PermissionModel(false, "QuanLyCayMucTieu", 5));
            permissionModels.Add(new PermissionModel(false, "QuanlyNhatKy", 6));

            foreach (var item in ModifyPermission.PERMISION_DETAIL)
                foreach (var item2 in permissionModels)
                    if (item.ActionDetail == item2.ActionDetail)
                    {
                        item2.isSelected = true;
                    }
        }
        private void ThemChucVu()
        {
            //if (selectedChucVu == null)
            //    return;
            //MessageBox.Show(selectedChucVu.TenChucVu);
            if(newChucVu.TenChucVu == String.Empty || newChucVu.TenChucVu == "")
            {
                MessageBox.Show("Vui lòng nhập tên chức vụ");
                return;
            }
            if(selectedPermission==null)
            {
                MessageBox.Show("Vui lòng chọn quyền ");
            }
            try { Convert.ToInt32(newChucVu.LuongCoBan); }
            catch
            {
                MessageBox.Show("Vui lòng đúng thông tin! ", "Thông báo!", MessageBoxButton.OK);
                return;
            }

            newChucVu.MaChucVu = ("CV" + DataProvider.Ins.DB.CHUCVUs.Count().ToString()).Replace(" ", "");
            newChucVu.ID_Permision = selectedPermission.ID_Permision;


            DataProvider.Ins.DB.CHUCVUs.Add(newChucVu);
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Thêm nhân viên mới thành công! ", "Thông báo!", MessageBoxButton.OK);
           
            newChucVu = new CHUCVU();
            newChucVu.MaChucVu = "";
            newChucVu.TenChucVu = "";
            newChucVu.LuongCoBan = 0;
            LoadListChucVu();
        }
        
        private void LoadListPermission()
        {
           
            listPermission.Clear();

            var list = DataProvider.Ins.DB.PERMISIONs.ToList();
            foreach (var items in list)
                listPermission.Add(items);

        }

        public void Edit(Window p)
        {
            if (listviewSelectedIndex < 0)
                return;
            SuaChucVu suaChucVuW = new SuaChucVu();

            SuaChucVuVM suaChucVuVM = new SuaChucVuVM(listChucVu[listviewSelectedIndex]);
            suaChucVuW.DataContext = suaChucVuVM;
            suaChucVuW.ShowDialog();
            LoadListChucVu();        
        }

    }
}
