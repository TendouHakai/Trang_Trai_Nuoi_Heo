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

namespace QuanLyTraiHeo.View.Windows.Thiết_lập_cây_mục_tiêu
{
    /// <summary>
    /// Interaction logic for Caymuctieu.xaml
    /// </summary>
    public partial class Caymuctieu : Window
    {
        public Caymuctieu()
        {
            InitializeComponent();
        }

        private void zoom_in_Click(object sender, RoutedEventArgs e)
        {
            UpdateViewBox(50);
        }

        private void UpdateViewBox(int newValue)
        {
            if ((Zoomviewbox.Width >= 0) && Zoomviewbox.Height >= 0)
            {
                Zoomviewbox.Width += newValue;
                Zoomviewbox.Height += newValue;
            }
        }

        private void _1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Doanh số không đạt chỉ tiêu dự kiến, không đủ tiền chi trả cho nhân viên và chi phí vận hành", "Chi tiết", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
