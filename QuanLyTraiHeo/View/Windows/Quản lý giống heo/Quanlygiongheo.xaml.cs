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


            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                Basegiongheo = _context.GIONGHEOs.ToList();
            }
            Datagrid_giongheo.ItemsSource = Basegiongheo;
        }

        /// <summary>
        /// Button event
        /// </summary>
        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            if (text1.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại heo.", "", MessageBoxButton.OK);
                return;
            }
            if (text2.Text == "" || text3.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin.", "", MessageBoxButton.OK);
                return;
            }
            if (text1.Text != "")
            {
                if (Isexist(text1.Text) == false)
                {
                    var t = new GIONGHEO
                    {
                        MaGiongHeo = text1.Text,
                        TenGiongHeo = text2.Text,
                        MoTa = text3.Text
                    };
                    Add_ustomer(t);
                }
                else
                {
                    MessageBox.Show("Đã tồn tại mã loại heo trên", "", MessageBoxButton.OK);
                }
            }
        }

        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            if (text1.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại heo.", "", MessageBoxButton.OK);
                return;
            }
            if (text2.Text == "" || text3.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin.", "", MessageBoxButton.OK);
                return;
            }
            if (text1.Text != "")
            {
                using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
                {
                    updating(text1.Text, text2.Text, text3.Text);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //using (TRANGTRAINUOIHEOEntities context = new TRANGTRAINUOIHEOEntities())
            {
                Timkiem(Find_textbox.Text);
            }
        }

        /// <summary>
        /// methods
        /// </summary>
        void updating(string a, string b, string c)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                var t = _context.GIONGHEOs.FirstOrDefault(GIONGHEO => GIONGHEO.MaGiongHeo.Contains(a));
                if (t != null)
                {
                    t.TenGiongHeo = b;
                    t.MoTa = c;
                    _context.SaveChanges();
                    reloadWithcontext(_context);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
                }
            }
        }

        public void Add_ustomer(GIONGHEO giongheo)
        {
            try
            {
                using (var context = new TRANGTRAINUOIHEOEntities())
                {
                    context.Entry(giongheo).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    reloadWithcontext(context);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập xuất", "", MessageBoxButton.OK);
            }
        }

        private void Timkiem(string a)
        {
            var t = DataProvider.Ins.DB.GIONGHEOs.Where(s => s.MaGiongHeo.Contains(a)).ToList();
            if (t != null)
            {
                Basegiongheo.Clear();
                foreach (var items in t)
                    Basegiongheo.Add(items);
                reloadWithDataprovider();
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
            }

        }

        private bool Isexist(string check)
        {
            var BaseGiongHeotemp = DataProvider.Ins.DB.GIONGHEOs.Where(s => s.MaGiongHeo.Contains(check)).ToList();
            if (BaseGiongHeotemp != null)
            {
                return false;
            }
            return true;
        }

        public void reloadWithcontext(TRANGTRAINUOIHEOEntities _context)
        {

            Datagrid_giongheo.ItemsSource = null;
            Basegiongheo = _context.GIONGHEOs.ToList();
            Datagrid_giongheo.ItemsSource = Basegiongheo;
        }

        private void reloadWithDataprovider()
        {
            Datagrid_giongheo.ItemsSource = null;
            Datagrid_giongheo.ItemsSource = Basegiongheo;
        }
    }
}
