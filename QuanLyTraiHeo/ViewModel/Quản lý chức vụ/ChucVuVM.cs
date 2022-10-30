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

namespace QuanLyTraiHeo.ViewModel
{
    public class ChucVuVM : BaseViewModel
    {
        public ObservableCollection<CHUCVU> listChucVu { get; set; }
        public ObservableCollection<PERMISION> listPermission { get; set; }
        public PERMISION selectedPermission { get; set; }
        public CHUCVU selectedChucVu { get; set; }
        public CHUCVU newChucVu { get; set; }
        public string textTimKiem { get; set; }
        public ICommand themCommand { get; set; }
        public ICommand suaCommand { get; set; }
        public ICommand TextTimKiemChangeCommand { get; set; }


        public ChucVuVM()
        {

            textTimKiem = "";
            listChucVu = new ObservableCollection<CHUCVU>();
            listPermission = new ObservableCollection<PERMISION>();
            selectedChucVu = new CHUCVU();
            newChucVu = new CHUCVU();
            selectedPermission = new PERMISION();

            themCommand = new RelayCommand<Grid>((p) => { return true; }, p => { ThemChucVu(); });
            suaCommand = new RelayCommand<Grid>((p) => { return true; }, p => { suaChucVu(); });
            TextTimKiemChangeCommand = new RelayCommand<ListView>((p) => { return true; }, p => {
                LoadListChucVu();
            });
            LoadListPermission();
            LoadListChucVu();
        }

        private void LoadListChucVu()
        {
            listChucVu.Clear();

            var list = DataProvider.Ins.DB.CHUCVUs.Where(s => s.TenChucVu.Contains(textTimKiem) ).ToList();
            foreach (var items in list)
                listChucVu.Add(items);
          
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
            LoadListChucVu();
        }
        
        private void LoadListPermission()
        {
           
            listPermission.Clear();

            var list = DataProvider.Ins.DB.PERMISIONs.ToList();
            foreach (var items in list)
                listPermission.Add(items);

        }
        private void suaChucVu ()
        {

        }
    }
}
