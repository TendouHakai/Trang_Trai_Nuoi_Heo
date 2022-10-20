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

namespace QuanLyTraiHeo.View.Windows.Quản_lý_loại_heo
{
    /// <summary>
    /// Interaction logic for Quanlyloaiheo.xaml
    /// </summary>
    public partial class Quanlyloaiheo : Window
    {
        public Quanlyloaiheo()
        {
            InitializeComponent();
        }
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            ThemLoaiHeo themLoaiHeo = new ThemLoaiHeo();
            themLoaiHeo.ShowDialog();
        }
        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            SuaLoaiHeo suaLoaiHeo = new SuaLoaiHeo();
            suaLoaiHeo.ShowDialog();
        }
    }
}
