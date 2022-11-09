using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows.Lập_lịch;
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

namespace QuanLyTraiHeo
{
    /// <summary>
    /// Interaction logic for LapLichTiem.xaml
    /// </summary>
    public partial class LapLichTiem : Window
    {
        public List<LICHTIEMHEO> Lichtiem { get; set; }
        public LICHTIEMHEO lICHTIEMHEO { get; set; }
        public LapLichTiem()
        {
            InitializeComponent();


            Lichtiem = DataProvider.Ins.DB.LICHTIEMHEOs.ToList();
            Listtiemheo.SelectedItem = lICHTIEMHEO;
            Listtiemheo.ItemsSource = Lichtiem;
            Listtiemheo.SelectionMode = SelectionMode.Extended;
        }
        //event
        private void add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add_LichTiem();
        }

        private void ListHeo_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListHeo();
        }

        //Function
        void Add_LichTiem()
        {
            LICHTIEMHEO lichtiem = new LICHTIEMHEO();
            lichtiem.MaLichTiem = Lichtiemcode_generate();
            lichtiem.MaHeo = Pigcode_text.Text;
            lichtiem.MaThuoc = Drugcode_text.Text;
            try
            {
                lichtiem.NgayTiem = Datepicker_Ngaytiem.SelectedDate.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày tiêm không hợp lệ");
                return;
            }
            try
            {
                lichtiem.LieuLuong = Convert.ToInt32(Lieuluong_text.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Hãy nhập liều lượng là giá trị số", "", MessageBoxButton.OK);
            }
            lichtiem.TrangThai = Trangthai_combobox.Text;
            {
                try
                {
                    DataProvider.Ins.DB.LICHTIEMHEOs.Add(lichtiem);
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (Exception)
                {

                    MessageBox.Show("Có thông tin nhập bị lỗi, yêu cầu nhập lại.", "", MessageBoxButton.OK);
                }
                reloadWithData();
            }
        }

        string Lichtiemcode_generate()
        {
            //create a function to generate random string
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        void reloadWithData()
        {
            Lichtiem = DataProvider.Ins.DB.LICHTIEMHEOs.ToList();
            Listtiemheo.ItemsSource = Lichtiem;
        }

        void ShowListHeo()
        {
            DanhsachHeo ds = new DanhsachHeo();
            ds.ShowDialog();
            Pigcode_text.Text = ds.TranferCode();
        }

        void ShowListThuoc()
        {
            DanhSachThuoc ds = new DanhSachThuoc();
            ds.ShowDialog();
            Drugcode_text.Text = ds.TranferCode();
        }

        private void ListThuoc_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListThuoc();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            LICHTIEMHEO lichtiem = (LICHTIEMHEO)Listtiemheo.SelectedItem;
            Delete(lichtiem);
        }
        
        private void btnFix_Click(object sender, RoutedEventArgs e)
        {
            LICHTIEMHEO tiemheo = (LICHTIEMHEO)Listtiemheo.SelectedItem;
            SuaLichHeo sua = new SuaLichHeo(tiemheo);
            sua.ShowDialog();
            updating(sua.returnValue());
        }

        

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Listtiemheo.SelectedItems.Clear();

            var item = sender as ListViewItem;
            if (item != null)
            {
                item.IsSelected = true;
                Listtiemheo.SelectedItem = item;
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                //To do somthing later
            }
        }

        public void updating(LICHTIEMHEO tt)
        {
            var t = DataProvider.Ins.DB.LICHTIEMHEOs.FirstOrDefault(LICHTIEMHEO => LICHTIEMHEO.MaLichTiem.Contains(tt.MaLichTiem));
            if (t != null)
            {
                t.NgayTiem = tt.NgayTiem;
                t.LieuLuong = tt.LieuLuong;
                t.TrangThai = tt.TrangThai;
                t.MaThuoc = tt.MaThuoc;
                t.MaHeo = tt.MaHeo;
                try
                {
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (Exception)
                {

                    MessageBox.Show("Yêu cầu nhập đúng mã heo cùng các thông tin", "", MessageBoxButton.OK);
                }
                reloadWithData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "", MessageBoxButton.OK);
            }
        }

        private void Delete(LICHTIEMHEO tiemheo)
        {
            try
            {
                var t = DataProvider.Ins.DB.LICHTIEMHEOs.FirstOrDefault(s => s.MaLichTiem.Contains(tiemheo.MaLichTiem.ToString()));
                DataProvider.Ins.DB.LICHTIEMHEOs.Remove(t);
                DataProvider.Ins.DB.SaveChanges();
                reloadWithData();
            }
            catch (Exception)
            {

                MessageBox.Show("Gặp lỗi khi xóa.", "", MessageBoxButton.OK);
            }
        }
        private int FindingCase()
        {
            int isMoreFieldCheck = 1;
            int takepartin = 0;
            
            if (Find_date.SelectedDate.HasValue != false)
            {
                isMoreFieldCheck++;
                takepartin += 1;
            }
            if (Find_loaiheo.Text != "")
            {
                if (isMoreFieldCheck != 1)
                {
                    isMoreFieldCheck++;
                }
                takepartin += 2;
            }
            if (Find_giongheo.Text != "")
            {
                if (isMoreFieldCheck != 1)
                {
                    isMoreFieldCheck++;                 
                }
                takepartin += 3;
            }
            if (Trangthai_combobox.SelectedValue.ToString() != "")
            {
                if (isMoreFieldCheck != 1)
                {
                    isMoreFieldCheck++;
                }
                takepartin += 4;
            }
                return 0;

        }
        private void Timkiem()
        {
            if((Find_date.Text != "")&&(Find_giongheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.GIONGHEO.TenGiongHeo.Contains(Find_giongheo.Text)).ToList();
                ti = ti.Where(s => s.NgayTiem == Find_date.SelectedDate.Value).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text != "") && (Find_loaiheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.LOAIHEO.TenLoaiHeo.Contains(Find_loaiheo.Text)).ToList();
                ti = ti.Where(s => s.NgayTiem == Find_date.SelectedDate.Value).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text != "") && (Find_loaiheo.Text != "")&&(Find_giongheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.LOAIHEO.TenLoaiHeo.Contains(Find_loaiheo.Text)).ToList();
                ti = ti.Where(s => s.NgayTiem == Find_date.SelectedDate.Value).ToList();
                ti = ti.Where(s => s.HEO.GIONGHEO.TenGiongHeo.Contains(Find_giongheo.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text != "") && (Find_loaiheo.Text == "") && (Find_giongheo.Text == ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.NgayTiem == Find_date.SelectedDate.Value).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text == "") && (Find_loaiheo.Text != "") &&(Find_giongheo.Text == ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.LOAIHEO.TenLoaiHeo.Contains(Find_loaiheo.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text == "") && (Find_loaiheo.Text == "") && (Find_giongheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.GIONGHEO.TenGiongHeo.Contains(Find_giongheo.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text == "") && (Find_loaiheo.Text != "") && (Find_giongheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.LOAIHEO.TenLoaiHeo.Contains(Find_loaiheo.Text)).ToList();
                ti = ti.Where(s => s.HEO.GIONGHEO.TenGiongHeo.Contains(Find_giongheo.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            if ((Find_date.Text != "") && (Find_loaiheo.Text == "") && (Find_giongheo.Text != ""))
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.LOAIHEO.TenLoaiHeo.Contains(Find_loaiheo.Text)).ToList();
                ti = ti.Where(s => s.NgayTiem == Find_date.SelectedDate.Value).ToList();
                Listtiemheo.ItemsSource = ti;
            }

            /*if (FindLoaiThuoc.Text != "")
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.MaThuoc.Contains(FindLoaiThuoc.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
            {
                var ti = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.HEO.GIONGHEO.TenGiongHeo.Contains(Find_giongheo.Text)).ToList();
                Listtiemheo.ItemsSource = ti;
            }
        }
    }
    var t = DataProvider.Ins.DB.LICHTIEMHEOs.Where(s => s.MaLichTiem.Contains(Timkiem_text.Text));
            Listtiemheo.ItemsSource = t;*/
        }
    

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Find_date.Text + Find_giongheo.Text + Find_loaiheo.Text);
            Timkiem();
        }
    }
}
            


