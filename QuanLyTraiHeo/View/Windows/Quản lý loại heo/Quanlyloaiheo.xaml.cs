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
using QuanLyTraiHeo.Model;

namespace QuanLyTraiHeo.View.Windows.Quản_lý_loại_heo
{
    /// <summary>
    /// Interaction logic for Quanlyloaiheo.xaml
    /// </summary>
    public partial class Quanlyloaiheo : Window
    {
        public List<LOAIHEO> BaseLoaiHeo { get; set; }
        public Quanlyloaiheo()
        {
            InitializeComponent();



            using(TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                BaseLoaiHeo =  _context.LOAIHEOs.ToList();
            }
            Datagrid_loaiheo.ItemsSource = BaseLoaiHeo;
        }

        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            var t = new LOAIHEO
            {
                MaLoaiHeo = Pigcode_textbox.Text,
                TenLoaiHeo = Pigname_textbox.Text,
                MoTa = Mota_textbox.Text
            };
            Add_ustomer(t);
        }

        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                updating(Pigcode_textbox.Text,Pigname_textbox.Text, Mota_textbox.Text);
            }
            
        }

        static void updating(string a, string b, string c)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                var t = _context.LOAIHEOs.FirstOrDefault(LOAIHEO => LOAIHEO.MaLoaiHeo.Contains(a));
                if (t != null)
                {
                    t.TenLoaiHeo = b;
                    t.MoTa = c;
                    _context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
                }
            }
        }

        static void Finding(TRANGTRAINUOIHEOEntities context, string a)
        {
            var t = context.LOAIHEOs.FirstOrDefault(LOAIHEO => LOAIHEO.MaLoaiHeo.Contains(a));
            if (t != null)
            {
                
                foreach(var c in context.LOAIHEOs)
                {

                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Thêm entity
        /// </summary>
        /// <param name="loaiheo"></param>
        public void Add_ustomer(LOAIHEO loaiheo)
        {
            using (var context = new TRANGTRAINUOIHEOEntities())
            {
                context.Entry(loaiheo).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

            private void Find_button_Click(object sender, RoutedEventArgs e)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                Finding(_context, Find_textbox.Text);
            }
        }
    }
}
