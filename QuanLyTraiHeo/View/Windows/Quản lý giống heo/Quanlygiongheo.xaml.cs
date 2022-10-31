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
using QuanLyTraiHeo.Model;

namespace QuanLyTraiHeo.View.Windows.Quản_lý_giống_heo
{
    /// <summary>
    /// Interaction logic for Quanlygiongheo.xaml
    /// </summary>
    public partial class Quanlygiongheo : Window
    {
        public List<GIONGHEO> Basegiongheo { get; set; }
        public Quanlygiongheo()
        {
            InitializeComponent();


            load();
        }
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            var t = new GIONGHEO
            {
                MaGiongHeo = text1.Text,
                TenGiongHeo = text2.Text,
                MoTa = text3.Text
            };
            Add_ustomer(t);
            Datagrid_giongheo.ItemsSource = null;
            load();
        }

        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                updating(text1.Text, text2.Text, text3.Text);
            }
        }

        void updating(string a, string b, string c)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                var t = _context.GIONGHEOs.FirstOrDefault(LOAIHEO => LOAIHEO.MaGiongHeo.Contains(a));
                if (t != null)
                {
                    t.TenGiongHeo = b;
                    t.MoTa = c;
                    _context.SaveChanges();
                    Datagrid_giongheo.ItemsSource = null;
                    load();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
                }
            }
        }

        public void Add_ustomer(GIONGHEO giongheo)
        {
            using (var context = new TRANGTRAINUOIHEOEntities())
            {
                context.Entry(giongheo).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void load()
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                Basegiongheo = _context.GIONGHEOs.ToList();
            }
            Datagrid_giongheo.ItemsSource = Basegiongheo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
