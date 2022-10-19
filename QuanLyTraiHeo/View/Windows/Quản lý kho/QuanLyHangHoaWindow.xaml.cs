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
    /// Interaction logic for QuanLyHangHoaWindow.xaml
    /// </summary>
    public partial class QuanLyHangHoaWindow : Window
    {
        public QuanLyHangHoaWindow()
        {
            InitializeComponent();
            list_HangHoa.Items.Add("Hàng hoá0");
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ThongTinHangHoa f = new ThongTinHangHoa();
            f.ShowDialog();
        }
    }
}
