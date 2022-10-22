using QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyTraiHeo
{
    /// <summary>
    /// Interaction logic for QuanLyThongTinNhanVienWindow.xaml
    /// </summary>
    public partial class QuanLyThongTinNhanVienWindow : Window
    {
        public QuanLyThongTinNhanVienWindow()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ThongTinNhanVien f = new ThongTinNhanVien();
            f.ShowDialog();
        }
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.ShowDialog();
        }
        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            SuaNhanVien suaNhanVien = new SuaNhanVien();
            suaNhanVien.ShowDialog();
        }
    }
}
