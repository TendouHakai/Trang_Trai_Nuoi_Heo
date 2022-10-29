using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using QuanLyTraiHeo.Model;

namespace QuanLyTraiHeo.ViewModel
{
    public class NhanVienVM:BaseViewModel
    {
        public List<NHANVIEN> listNhanvien { get; set; }
        public ICommand ThemNhanVienCommand { get; set; }
        public NhanVienVM()
        {
            listNhanvien = new List<NHANVIEN>();
            ThemNhanVienCommand = new RelayCommand<Grid>((p) => { return true; }, p => { ThemNhanVien(); });
            LoadListNhanVien();
        }
        public void ThemNhanVien()
        {
            MessageBox.Show("aaaa");
        }
        private void LoadListNhanVien()
        {
            var listnhanvien = DataProvider.Ins.DB.NHANVIENs.ToList();
            foreach (var items in listnhanvien)
                listNhanvien.Add(items);
        }
    }
}
