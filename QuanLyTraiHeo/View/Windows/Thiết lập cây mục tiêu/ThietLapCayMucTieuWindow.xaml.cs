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
using QuanLyTraiHeo.Model;

namespace QuanLyTraiHeo
{
    /// <summary>
    /// Interaction logic for ThietLapCayMucTieuWindow.xaml
    /// </summary>
    public partial class ThietLapCayMucTieuWindow : Window
    {
        Caymuctieu cmt;
        Object obj;
        static int check = 0;
        public List<LICHTIEMHEO> Lichtiem { get; set; }
        public List<HEO> Heo { get; set; }
        public List<LICHPHOIGIONG> LichPhoiGiong { get; set; }
        int Year1;
        int Year2;
        public ThietLapCayMucTieuWindow()
        {
            InitializeComponent();
            cmt = new Caymuctieu((int?)OutlinedComboBox.SelectedItem,(int?)OutlinedComboBox1.SelectedItem);            
            cmt.Close();
            obj = cmt.Content;
            cmt.Content = null;
            showmake.Children.Clear();
            showmake.Children.Add(obj as UIElement);
        }
        
        void changeView()
        {
            if ((OutlinedComboBox.SelectedItem != null) && (OutlinedComboBox1.SelectedItem != null))
            {
                Year1 = Convert.ToInt16(OutlinedComboBox.Text);
                Year2 = Convert.ToInt16(OutlinedComboBox1.Text);
                cmt.Caculate(Year1, Year2);
            }
            else
            {
                cmt.Input((int?)OutlinedComboBox.SelectedItem, (int?)OutlinedComboBox1.SelectedItem);
            }
        }
        private void BoLoc(object sender, RoutedEventArgs e)
        {
            changeView();
        }
    }
}
