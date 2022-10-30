using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên;
using ListView = System.Windows.Controls.ListView;

namespace QuanLyTraiHeo.ViewModel
{
    public class NhanVienVM:BaseViewModel
    {
        public ObservableCollection<NHANVIEN> listNhanvien { get; set; }
        public int listviewSelectedIndex { get; set; }
        public string textTimKiem { get; set; }
        public ICommand ThemNhanVienCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand TextTimKiemChangeCommand { get; set; }

        public NhanVienVM()
        {
            textTimKiem = "";
            listNhanvien = new ObservableCollection<NHANVIEN>();
            listviewSelectedIndex = 0;
            ThemNhanVienCommand = new RelayCommand<Window>((p) => { return true; }, p => { ThemNhanVien(p); });
            EditCommand = new RelayCommand<Window>((p) => { return true; }, p => { Edit(p); });
            TextTimKiemChangeCommand = new RelayCommand<ListView>((p) => { return true; }, p => { TextTimKiemChanged(p); });
            LoadListNhanVien();
        }
        public void ThemNhanVien(Window p)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.ShowDialog();
        }

        private void TextTimKiemChanged(ListView p)
        {
            LoadListNhanVien(p);
            
        }
        private void LoadListNhanVien(ListView p  = null)
        {
            listNhanvien.Clear();

            var listnhanvien = DataProvider.Ins.DB.NHANVIENs.Where(s => s.HoTen.Contains(textTimKiem)).ToList();
            foreach (var items in listnhanvien)
                listNhanvien.Add(items);
        }

        public void Edit(Window p)
        {
            if(listviewSelectedIndex <0)
                return;
            SuaNhanVienVM suaNhanVienVM = new SuaNhanVienVM(listNhanvien[listviewSelectedIndex]);
            SuaNhanVien suaNhanVien = new SuaNhanVien();
            suaNhanVien.DataContext = suaNhanVienVM;
            suaNhanVien.ShowDialog();
        }
    }
}
