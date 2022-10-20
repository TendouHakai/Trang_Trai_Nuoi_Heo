using QuanLyTraiHeo.View.Windows.Quản_lý_đàn_heo;
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
    /// Interaction logic for QuanLyThongTinCaTheWindow.xaml
    /// </summary>
    public partial class QuanLyThongTinCaTheWindow : Window
    {
        public QuanLyThongTinCaTheWindow()
        {
            InitializeComponent();

            Listview.Items.Add("abc");
            Listview.Items.Add("cde");
        }

        private void Edit_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("KKK");
        }
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            ThemTTHeo themTTHeo = new ThemTTHeo();
            themTTHeo.ShowDialog();
        }
        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            SuaTTHeo suaTTHeo = new SuaTTHeo();
            suaTTHeo.ShowDialog();
        }
    }
}
