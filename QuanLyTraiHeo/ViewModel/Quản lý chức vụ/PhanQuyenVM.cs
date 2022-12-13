using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using QuanLyTraiHeo.Model;
using MessageBox = System.Windows.MessageBox;

namespace QuanLyTraiHeo.ViewModel
{
    public class PhanQuyenVM : BaseViewModel
    {
        private PERMISION modifyPermission { get; set; }
        public PERMISION ModifyPermission { get => modifyPermission; set { modifyPermission = value; OnPropertyChanged(); } }
        private string permissionName { get; set; }
        public string PermissionName { get => permissionName; set { permissionName = value; OnPropertyChanged(); } }
        public ObservableCollection<PERMISION> lstPermission { get; set; }
        public ICommand ChinhSuaPermissionCommand { get; set; }
        public ICommand permissionSelectionChangedCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddPerCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public ObservableCollection<PermissionModel> permissionModels { get; set; }
        
        public int lstPermissionIndex { get; set; }
        public PhanQuyenVM()
        {
            permissionModels = new ObservableCollection<PermissionModel>();
            lstPermission = new ObservableCollection<PERMISION>();
            ChinhSuaPermissionCommand = new RelayCommand<Button>((p) => { return true; }, p => { ChinhSuaPermission(); });
            permissionSelectionChangedCommand = new RelayCommand<Button>((p) => { return true; }, p => { PermissionSelectionChanged(); });
            DeleteCommand = new RelayCommand<Button>((p) => { return true; }, p => { DeletePermission(); });
            AddPerCommand = new RelayCommand<Button>((p) => { return true; }, p => { AddPermission(); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, p => { p.Close(); });


            LoadlstPermission();

            permissionModels.Clear();
            permissionModels.Add(new PermissionModel(false, "Quản lý nhân viên", 1));
            permissionModels.Add(new PermissionModel(false, "Quản lý đàn heo", 2));
            permissionModels.Add(new PermissionModel(false, "Quản lý kho", 3));
            permissionModels.Add(new PermissionModel(false, "Quản lý tài chính", 4));
            permissionModels.Add(new PermissionModel(false, "Quản lý cây mục tiêu", 5));
            permissionModels.Add(new PermissionModel(false, "Quản lý nhật ký", 6));

        }
        private void LoadlstPermission()
        {

            lstPermission.Clear();

            var list = DataProvider.Ins.DB.PERMISIONs.ToList();
            foreach (var items in list)
                lstPermission.Add(items);

        }

        private void ChinhSuaPermission()
        {
            if (ModifyPermission == null)
                return;
            if (PermissionName == String.Empty)
            {
                MessageBox.Show("Vui lòng điền tên chức vụ!");
                return;
            }
            int i = DataProvider.Ins.DB.PERMISIONs.Where(p => (p.Name_Permision == PermissionName && ModifyPermission.ID_Permision != p.ID_Permision)).Count();
            if(i > 0)
            {
                MessageBox.Show("Tên chức vụ bị trùng, vui lòng chọn tên khác!");
                return;
            }

            DataProvider.Ins.DB.PERMISION_DETAIL.RemoveRange(DataProvider.Ins.DB.PERMISION_DETAIL.Where(x => x.ID_Permision == ModifyPermission.ID_Permision));
            DataProvider.Ins.DB.SaveChanges();

            foreach (var item in permissionModels)
                if (item.isSelected)
                {
                    PERMISION_DETAIL pERMISION_DETAIL = new PERMISION_DETAIL();
                    pERMISION_DETAIL.ID_PermisionDetail = ("PD" + ModifyPermission.ID_Permision + item.number.ToString()).ToString().Replace(" ", "");
                    pERMISION_DETAIL.ActionDetail = item.ActionDetail;
                    pERMISION_DETAIL.ID_Permision = ModifyPermission.ID_Permision;
                    DataProvider.Ins.DB.PERMISION_DETAIL.Add(pERMISION_DETAIL);
                }
                DataProvider.Ins.DB.SaveChanges();
            
            MessageBox.Show("Chỉnh sửa thành công!");

            ModifyPermission = lstPermission[lstPermissionIndex];
        }

        private void DeletePermission()
        {

            int count = DataProvider.Ins.DB.CHUCVUs.Where(x => x.ID_Permision == ModifyPermission.ID_Permision).Count();
            if(count > 0)
            {
                MessageBox.Show("Đang có chức vụ có quyền này, không thể xóa!");
                return;
            }


            DataProvider.Ins.DB.PERMISION_DETAIL.RemoveRange(DataProvider.Ins.DB.PERMISION_DETAIL.Where(x => x.ID_Permision == ModifyPermission.ID_Permision));
            DataProvider.Ins.DB.PERMISIONs.Remove( ModifyPermission);

            DataProvider.Ins.DB.SaveChanges();
            LoadlstPermission();
            MessageBox.Show("Xóa thành công !");

        }

        private void AddPermission()
        {
            if (PermissionName == String.Empty)
            {
                MessageBox.Show("Vui lòng điền tên chức vụ!");
                return;
            }
            int i = DataProvider.Ins.DB.PERMISIONs.Where(p => (p.Name_Permision == PermissionName)).Count();
            if (i > 0)
            {
                System.Windows.MessageBox.Show("Tên chức vụ bị trùng, vui lòng chọn tên khác!");
                return;
            }

            ModifyPermission = new PERMISION();
            ModifyPermission.ID_Permision = "Per" + lstPermission.Count.ToString();
            ModifyPermission.Name_Permision = PermissionName;
            DataProvider.Ins.DB.PERMISIONs.Add(ModifyPermission);
            DataProvider.Ins.DB.SaveChanges();

            LoadlstPermission();
            MessageBox.Show("Thêm thành công !");
        }
        private void PermissionSelectionChanged()
        {
            if (ModifyPermission == null)
                return;
            PermissionName = ModifyPermission.Name_Permision;
            permissionModels.Clear();
            permissionModels.Add(new PermissionModel(false, "Quản lý nhân viên", 1));
            permissionModels.Add(new PermissionModel(false, "Quản lý đàn heo", 2));
            permissionModels.Add(new PermissionModel(false, "Quản lý kho", 3));
            permissionModels.Add(new PermissionModel(false, "Quản lý tài chính", 4));
            permissionModels.Add(new PermissionModel(false, "Quản lý cây mục tiêu", 5));
            permissionModels.Add(new PermissionModel(false, "Quản lý nhật ký", 6));
            foreach (var item in ModifyPermission.PERMISION_DETAIL)
                foreach (var item2 in permissionModels)
                    if (item.ActionDetail == item2.ActionDetail)
                    {
                        item2.isSelected = true;
                    }
        }


    }
}
