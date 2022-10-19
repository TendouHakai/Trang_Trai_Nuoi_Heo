using System;
using QuanLyTraiHeo.View.Windows.Thiết_lập_cây_mục_tiêu;
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
    /// Interaction logic for ThietLapCayMucTieuWindow.xaml
    /// </summary>
    public partial class ThietLapCayMucTieuWindow : Window
    {
        public ThietLapCayMucTieuWindow()
        {
            InitializeComponent();
            Caymuctieu cmt = new Caymuctieu();
            cmt.Close();
            Object obj = cmt.Content;
            cmt.Content = null;
            showmake.Children.Clear();
            showmake.Children.Add(obj as UIElement);
        }
    }
}
