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

        /*#region Properties
        public ObservableCollection<ChonHeo> ListChonHeo { get => _listChonHeo; set { _listChonHeo = value; OnPropertyChanged(); } }
        public ObservableCollection<HEO> ListHEO { get => _listHEO; set { _listHEO = value; OnPropertyChanged(); } }
        #endregion*/
        List<HEO> Listheo { get; set;}
        List<ChonHeo> ListChonHeo { get; set; }
        public HEO heo { get; set; }

        public int check = 0;
        
        public DanhsachHeo()
        {
            InitializeComponent(); 
            Listheo = DataProvider.Ins.DB.HEOs.ToList();
            //ListChonHeo = new List<ChonHeo>();
            foreach(var Heo in Listheo)
            {
                ChonHeo chonheo = new ChonHeo();
                chonheo.heo = Heo;
                chonheo.IsChecked = false;
                chonheo.Tuoi = (int)(DateTime.Now - (DateTime)Heo.NgaySinh).TotalDays;
                if(chonheo.Tuoi < 30)
                {
                    chonheo.ShowTuoi = chonheo.Tuoi.ToString() + " ngày";
                }
                if(chonheo.Tuoi >= 30)
                {
                    chonheo.ShowTuoi = (chonheo.Tuoi / 30).ToString() + " tháng " + (chonheo.Tuoi % 30).ToString() + " ngày";
                }
                if(chonheo.Tuoi >= 365)
                {
                    chonheo.ShowTuoi = ((chonheo.Tuoi / 30)/12).ToString() + " năm " + (chonheo.Tuoi % 365).ToString() + " ngày";
                }
                _listChonHeo.Add(chonheo);
            }
            ListMaHeo_.ItemsSource = _listChonHeo;
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
        
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListMaHeo_.SelectedItems.Clear();

            var item = sender as ListViewItem;
            if (item != null)
            {
                item.IsSelected = true;
                ListMaHeo_.SelectedItem = item;
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {

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
    }
}
