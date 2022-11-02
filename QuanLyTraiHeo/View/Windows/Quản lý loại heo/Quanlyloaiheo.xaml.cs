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


            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                BaseLoaiHeo = _context.LOAIHEOs.ToList();
            }
            Datagrid_loaiheo.ItemsSource = BaseLoaiHeo;
        }

        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            if (Pigcode_textbox.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại heo.", "", MessageBoxButton.OK);
                return;
            }
            if (Pigname_textbox.Text == "" || Mota_textbox.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin.", "", MessageBoxButton.OK);
                return;
            }
            if (Pigcode_textbox.Text != "")
            {
                if (Isexist(Pigcode_textbox.Text) == false)
                {
                    var t = new LOAIHEO
                    {
                        MaLoaiHeo = Pigcode_textbox.Text,
                        TenLoaiHeo = Pigname_textbox.Text,
                        MoTa = Mota_textbox.Text
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
            if (Pigcode_textbox.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại heo.", "", MessageBoxButton.OK);
                return;
            }
            if (Pigname_textbox.Text == "" || Mota_textbox.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin.", "", MessageBoxButton.OK);
                return;
            }
            if (Pigcode_textbox.Text != "")
            {
                using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
                {
                    updating(Pigcode_textbox.Text, Pigname_textbox.Text, Mota_textbox.Text);
                }
            }
        }

        private void Find_button_Click(object sender, RoutedEventArgs e)
        {
            /*using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                Finding(_context, Find_textbox.Text);              
            }*/
            Timkiem(Find_textbox.Text);
        }


        /// <summary>
        /// Thêm entity
        /// </summary>
        /// <param name="loaiheo"></param>
        private void Add_ustomer(LOAIHEO loaiheo)
        {
            try
            {
                using (var context = new TRANGTRAINUOIHEOEntities())
                {
                    context.Entry(loaiheo).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    reloadUsingcontext(context);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập xuất", "", MessageBoxButton.OK);
            }
        }

        void updating(string a, string b, string c)
        {
            using (TRANGTRAINUOIHEOEntities _context = new TRANGTRAINUOIHEOEntities())
            {
                var t = _context.LOAIHEOs.FirstOrDefault(LOAIHEO => LOAIHEO.MaLoaiHeo.Contains(a));
                if (t != null)
                {
                    t.TenLoaiHeo = b;
                    t.MoTa = c;
                    _context.SaveChanges();
                    reloadUsingcontext(_context);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
                }
            }
        }

        private void Timkiem(string a)
        {

            var BaseLoaiHeotemp = DataProvider.Ins.DB.LOAIHEOs.Where(s => s.MaLoaiHeo.Contains(a)).ToList();
            if (BaseLoaiHeotemp != null)
            {
                BaseLoaiHeo.Clear();
                foreach (var items in BaseLoaiHeotemp)
                {
                    BaseLoaiHeo.Add(items);
                }
                reloadUsingDTProvider();
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
            }

        }

        private bool Isexist(string check)
        {
            var BaseLoaiHeotemp = DataProvider.Ins.DB.LOAIHEOs.Where(s => s.MaLoaiHeo.Contains(check)).ToList();
            if (BaseLoaiHeotemp != null)
            {
                return false;
            }
            return true;
        }

        void reloadUsingDTProvider()
        {
            Datagrid_loaiheo.ItemsSource = null;
            Datagrid_loaiheo.ItemsSource = BaseLoaiHeo;
        }
        void reloadUsingcontext(TRANGTRAINUOIHEOEntities _context)
        {
            Datagrid_loaiheo.ItemsSource = null;
            BaseLoaiHeo = _context.LOAIHEOs.ToList();
            Datagrid_loaiheo.ItemsSource = BaseLoaiHeo;
        }

        ///For fail method. Delete after release
        /*static void Finding(TRANGTRAINUOIHEOEntities context, string a)
        {
            var t = context.LOAIHEOs.FirstOrDefault(LOAIHEO => LOAIHEO.MaLoaiHeo.Contains(a));

        }*/
    }
}
