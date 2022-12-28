using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows.Quản_lý_chức_vụ;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using QuanLyTraiHeo.View.Windows;
using System.Data;
using System.Drawing;
using ServiceStack.Text;

namespace QuanLyTraiHeo.View.Windows.Lập_lịch
{
    /// <summary>
    /// Interaction logic for DanhsachHeo.xaml
    /// </summary>
    public partial class DanhsachHeo : Window
    {
        #region Attributes
        
        private ObservableCollection<ChonHeo> _listChonHeo = new ObservableCollection<ChonHeo>();
        public ObservableCollection<HEO> _listHEO = new ObservableCollection<HEO>();
        #endregion
        public ObservableCollection<LichTiem_TenThuoc> Thuoc_Tiem = new ObservableCollection<LichTiem_TenThuoc>();
        List<LICHTIEMHEO> ListLichTiem = new List<LICHTIEMHEO>();
        List<string> ListMaChuong = new List<string>() { "All"};
        List<string> ListLichSuTiem = new List<string>() { };
        List<HEO> Listheo { get; set;}
        List<ChonHeo> ListChonHeo { get; set; }
        public HEO heo { get; set; }

        public int check = 0;
        
        public DanhsachHeo()
        {
            InitializeComponent();
            ListLichTiem = DataProvider.Ins.DB.LICHTIEMHEOs.ToList();
            foreach (var lichtiem in ListLichTiem)
            {
                LichTiem_TenThuoc lichTiem_TenThuoc = new LichTiem_TenThuoc
                {
                    lichtiem = lichtiem,
                    hanghoa = DataProvider.Ins.DB.HANGHOAs.FirstOrDefault(s => s.MaHangHoa.Contains(lichtiem.MaThuoc))
                };
                Thuoc_Tiem.Add(lichTiem_TenThuoc);
            }
            //pre-check
            Listheo = DataProvider.Ins.DB.HEOs.ToList();
            //load
            loadMaChuong();
            loadDatagrid("All");
        }

        /*        private void check_click(object sender, RoutedEventArgs e)
                {
                    this.Close();
                }*/

        /*void loadDSHeo()
        {
            _listChonHeo = new ObservableCollection<ChonHeo>();

            //listNGUOIGUI = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(x => x.CHUCVU.MaChucVu == maChucVu));

            //var nhanviens = DataProvider.Ins.DB.NHANVIENs;
            var Nhanviens = DataProvider.Ins.DB.NHANVIENs.ToList();
            if (maChucVu != null)
                Nhanviens = Nhanviens.Where(x => x.MaChucVu == maChucVu).ToList();

            foreach (var Nhanvien in Nhanviens)
            {
                NguoiGui nguoigui = new NguoiGui();
                nguoigui.nhanvien = Nhanvien;
                nguoigui.IsChecked = false;
                listNHANVIEN.Add(nguoigui);
            }
        }*/
        //Lay danh sach heo da chon
        void loadDSChonHeo()
        {
            foreach (var heo in _listChonHeo)
            {
                if (heo.IsChecked == true)
                {
                    _listHEO.Add(heo.heo);
                }
            }
        }
        
        //Lay ma chuong
        void loadMaChuong()
        {
            foreach(CHUONGTRAI CT in DataProvider.Ins.DB.CHUONGTRAIs)
            {
                ListMaChuong.Add(CT.MaChuong);
            }
            MaChuong_CB.ItemsSource = ListMaChuong;
        }

        //load datagrid theo mau
        void loadDatagrid(string MaChuong)
        {
            ReloadDatagrid();
            foreach (var Heo in Listheo)
            {
                if (MaChuong == "All")
                {
                    ChonHeo chonheo = new ChonHeo();
                    chonheo.heo = Heo;
                    chonheo.IsChecked = false;
                    chonheo.Tuoi = (int)(DateTime.Now - (DateTime)Heo.NgaySinh).TotalDays;
                    TuoiHeo(chonheo);
                    _listChonHeo.Add(chonheo);
                }
                else
                {
                    if (Heo.MaChuong == MaChuong)
                    {
                        ChonHeo chonheo = new ChonHeo();
                        chonheo.heo = Heo;
                        chonheo.IsChecked = false;
                        chonheo.Tuoi = (int)(DateTime.Now - (DateTime)Heo.NgaySinh).TotalDays;
                        TuoiHeo(chonheo);
                        _listChonHeo.Add(chonheo);
                    }
                }
            }
            ListMaHeo_.ItemsSource = _listChonHeo;
        }

        //Ham Tinh Tuoi Heo
        void TuoiHeo(ChonHeo chonheo)
        {
            if (chonheo.Tuoi < 30)
            {
                chonheo.ShowTuoi = chonheo.Tuoi.ToString() + " ngày";
            }
            if (chonheo.Tuoi >= 30)
            {
                chonheo.ShowTuoi = (chonheo.Tuoi / 30).ToString() + " tháng " + (chonheo.Tuoi % 30).ToString() + " ngày";
            }
            if (chonheo.Tuoi >= 365)
            {
                chonheo.ShowTuoi = ((chonheo.Tuoi / 30) / 12).ToString() + " năm " + (chonheo.Tuoi % 365).ToString() + " ngày";
            }
        }

        //Reload lai datagrid
        void ReloadDatagrid()
        {
            _listChonHeo.Clear();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListMaHeo_.SelectedItems.Clear();

            var item = sender as DataGridRow;
            if (item != null)
            {
                item.IsSelected = true;
                ListMaHeo_.SelectedItem = item;
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridRow item = sender as DataGridRow;
            if (item != null && item.IsSelected)
            {
                LichSuTiem_TB.Clear();
                ListLichSuTiem.Clear();
                ChonHeo CH = ListMaHeo_.SelectedItem as ChonHeo;
                foreach(LICHTIEMHEO TH in CH.heo.LICHTIEMHEOs)
                {                    
                    ListLichSuTiem.Add(Thuoc_Tiem.FirstOrDefault(s => s.lichtiem.MaLichTiem.Equals(TH.MaLichTiem)).hanghoa.TenHangHoa + " vào ngày " + Thuoc_Tiem.FirstOrDefault(s => s.lichtiem.MaLichTiem.Equals(TH.MaLichTiem)).lichtiem.NgayTiem);
                }   
                if(ListLichSuTiem.IsNullOrEmpty())
                {
                    LichSuTiem_TB.Text = "Heo chưa ghi nhận được tiêm.";
                }
                else
                {
                    foreach (var a in ListLichSuTiem)
                    {
                        LichSuTiem_TB.Text += "Đã tiêm " + a + "\n";
                    }
                }    
            }
        }

        public string TranferCode()
        {
            heo = (HEO)ListMaHeo_.SelectedItem;
            return heo.MaHeo;
        }

        private void Confirm_button_Click(object sender, RoutedEventArgs e)
        {
            check = 1;
            loadDSChonHeo();
            this.Close();
        }

        private void Huy_button_Click(object sender, RoutedEventArgs e)
        {
            check = 0;
            this.Close();
        }

        private void MaChuong_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadDatagrid(MaChuong_CB.SelectedItem as string);
        }
    }
}
