using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class CapNhatTaiKhoanVM : BaseViewModel
    {
        #region Attributes
        private NHANVIEN nhanVien;
        List<string> lstGender;

        string hoTen;
        string diaChi;
        string email;
        int? heSoLuong;
        string gioiTinh;
        DateTime? ngayVaoLam;
        DateTime? ngaySinh;
        string sDT;
        
        #endregion

        #region Property
        public NHANVIEN NhanVien { get => nhanVien; set { nhanVien = value; OnPropertyChanged(); } }

        public List<string> LstGender { get => lstGender; set => lstGender = value; }


        public string GioiTinh { get => gioiTinh; set { gioiTinh = value; OnPropertyChanged(); } }
        public string HoTen { get => hoTen; set { hoTen = value; OnPropertyChanged(); } }
        public string DiaChi { get => diaChi; set { diaChi = value; OnPropertyChanged(); } }
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        public int? HeSoLuong { get => heSoLuong; set { heSoLuong = value; OnPropertyChanged(); } }
        public DateTime? NgayVaoLam { get => ngayVaoLam; set { ngayVaoLam = value; OnPropertyChanged(); } }
        public DateTime? NgaySinh { get => ngaySinh; set { ngaySinh = value; OnPropertyChanged(); } }
        public string SDT { get => sDT; set { sDT = value; OnPropertyChanged(); } }

        public MainWindowVM MainWindowMD { get; set; }

        #endregion

        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Event command


        #endregion
        public CapNhatTaiKhoanVM(MainWindowVM mainWindowMD)
        {
            MainWindowMD = mainWindowMD;

            LoadInformation();

            UpdateCommand = new RelayCommand<object>((p) => { return true; }, p => { UpdateInformation(); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, p => { CloseWindow(p); });
        }

        #region Method

        void LoadInformation()
        {
            if (MainWindowMD.NhanVien == null) return;

            HoTen = MainWindowMD.NhanVien.HoTen;
            SDT = MainWindowMD.NhanVien.SDT;
            DiaChi = MainWindowMD.NhanVien.DiaChi;
            Email = MainWindowMD.NhanVien.email;
            NgayVaoLam = MainWindowMD.NhanVien.NgayVaoLam;
            NgaySinh = MainWindowMD.NhanVien.NgaySinh;
            HeSoLuong = MainWindowMD.NhanVien.HeSoLuong;

            LstGender = new List<string>() { "Nam", "Nữ" };
            if (MainWindowMD.NhanVien.GioiTinh == "Nam")
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
        }
        void UpdateInformation()
        {
            if (MessageBox.Show("Bạn có chắc muốn thay đổi thông tin?", "Chú ý", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindowMD.NhanVien.HoTen = HoTen;
                MainWindowMD.NhanVien.SDT = SDT;
                MainWindowMD.NhanVien.DiaChi = DiaChi;
                MainWindowMD.NhanVien.email = Email;
                MainWindowMD.NhanVien.NgayVaoLam = NgayVaoLam;
                MainWindowMD.NhanVien.NgaySinh = NgaySinh;
                MainWindowMD.NhanVien.HeSoLuong = HeSoLuong;
                MainWindowMD.NhanVien.GioiTinh = GioiTinh;
                DataProvider.Ins.DB.SaveChanges();
                MainWindowMD.UpdateNhanVien();
                MessageBox.Show("Thay đổi thành công");
            }
            else
            {

            }
        }

        void CloseWindow(Window p)
        {
            MessageBoxResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButton.YesNo);
            if (dlr == MessageBoxResult.Yes)
            {
                p.Close();
                return;
            }
            return;
        }

        #endregion
    }
}