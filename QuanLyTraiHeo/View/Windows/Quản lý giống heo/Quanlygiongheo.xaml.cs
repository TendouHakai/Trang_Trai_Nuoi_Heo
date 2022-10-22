using QuanLyTraiHeo.View.Windows.Quản_lý_loại_heo;
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

namespace QuanLyTraiHeo.View.Windows.Quản_lý_giống_heo
{
    /// <summary>
    /// Interaction logic for Quanlygiongheo.xaml
    /// </summary>
    public partial class Quanlygiongheo : Window
    {
        public Quanlygiongheo()
        {
            InitializeComponent();
        }
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            ThemGiongHeo themGiongHeo = new ThemGiongHeo();
            themGiongHeo.ShowDialog();
        }

        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            SuaGiongHeo suaGiongHeo = new SuaGiongHeo();
            suaGiongHeo.ShowDialog();
        }
    }
}
