using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using WpfApp_MVVM.View.Windows;

namespace QuanLyTraiHeo.ViewModel
{
    public class MainWindowVM: BaseViewModel
    {
        public bool IsLoaded = false;
        private string _currentWindow = "";
        public string currentWindow { get => _currentWindow; set { _currentWindow = value; OnPropertyChanged(); } }
        #region CommandOpenWindow
        public ICommand OpenTrangChuWindow { get; set; }
        public ICommand OpenQuanLyThongTinCaTheWindow { get; set; }
        public ICommand OpenLapPhieuBanNhapHeoWIndow { get; set; }
        public ICommand OpenLapLichWindow { get; set; } 
        public ICommand OpenQuanLyThongTinChuongWindow { get; set; }
        public ICommand OpenLapPhieuSuaChuaWindow { get; set; }
        public ICommand OpenQuanLyHangHoaTrongKhoWindow { get; set; }
        public ICommand OpenLapPhieuKhoWindow { get; set; }
        public ICommand OpenBaoCaoTinhTrangDanHeoWindow { get; set; }
        public ICommand OpenBaoCaoSuaChuaWindow { get; set; }
        public ICommand OpenBaoCaoThuChiWindow { get; set; }
        public ICommand OpenBaoCaoTonKhoWindow { get; set; }
        public ICommand OpenQuanLyThongTinNhanVienWindow { get; set; }
        public ICommand OpenTraCuuPhieuThuChiWindow { get; set; }
        public ICommand OpenQuanLyNhatKyWindow { get; set; }
        public ICommand OpenThietLapCayMucTieuWindow { get; set; }
        #endregion
        public ICommand LoadedWindowCommand { get; set; }
        public MainWindowVM()   
        {
            currentWindow = "Trang chủ";
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, p => {
                IsLoaded = true;
                p.Hide();
                
                wLogin wLogin = new wLogin();
                wLogin.ShowDialog();

                if (wLogin.DataContext == null) return;

                var loginWD = wLogin.DataContext as LoginVM;

                if (loginWD.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }

            });
            #region CodeCommandOpenWindow
            OpenTrangChuWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                TrangChuWindow wc = new TrangChuWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Trang chủ";
            });
            OpenQuanLyThongTinCaTheWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                QuanLyThongTinCaTheWindow wc = new QuanLyThongTinCaTheWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Quản lý thông tin cá thể";
            });
            OpenLapPhieuBanNhapHeoWIndow = new RelayCommand<Grid>((p) => { return true; }, p => {
                LapPhieuBanNhapHeoWindow wc = new LapPhieuBanNhapHeoWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập phiếu bán/nhập heo";
            });
            OpenLapLichWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                LapLichWindow wc = new LapLichWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập lịch tiêm/phối giống heo";
            });
            OpenQuanLyThongTinChuongWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                QuanLyThongTinChuong wc = new QuanLyThongTinChuong();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Quản lý thông tin chuồng nuôi";
            });
            OpenLapPhieuSuaChuaWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                LapLichWindow wc = new LapLichWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập phiếu sửa chữa";
            });
            OpenQuanLyHangHoaTrongKhoWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                QuanLyHangHoaWindow wc = new QuanLyHangHoaWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Quản lý hàng hoá trong kho";
            });
            OpenLapPhieuKhoWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                LapPhieuKhoWindow wc = new LapPhieuKhoWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập phiếu kho";
            });
            OpenBaoCaoTinhTrangDanHeoWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                BaoCaoTinhTrangDanHeoWindow wc = new BaoCaoTinhTrangDanHeoWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập báo cáo tình trạng đàn heo";
            });
            OpenBaoCaoSuaChuaWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                BaoCaoSuaChuaWindow wc = new BaoCaoSuaChuaWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập báo cáo sửa chữa";
            });
            OpenBaoCaoThuChiWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                BaoCaoThuChiWindow wc = new BaoCaoThuChiWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập lịch tiêm/phối giống heo";
            });
            OpenBaoCaoTonKhoWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                BaoCaoTonKhoWindow wc = new BaoCaoTonKhoWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Lập báo cáo tồn kho";
            });
            OpenQuanLyThongTinNhanVienWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                QuanLyThongTinNhanVienWindow wc = new QuanLyThongTinNhanVienWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Quản lý thông tin nhân viên";
            });
            OpenTraCuuPhieuThuChiWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                TraCuuPhieuThuChiWindow wc = new TraCuuPhieuThuChiWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Tra cứu phiếu thu chi";
            });
            OpenQuanLyNhatKyWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                QuanLyNhatKyWindow wc = new QuanLyNhatKyWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Quản lý nhật ký";
            });
            OpenThietLapCayMucTieuWindow = new RelayCommand<Grid>((p) => { return true; }, p => {
                ThietLapCayMucTieuWindow wc = new ThietLapCayMucTieuWindow();
                wc.Close();
                Object content = wc.Content;
                wc.Content = null;
                p.Children.Clear();
                p.Children.Add(content as UIElement);
                currentWindow = "Thiết lập cây mục tiêu";
            });
            #endregion

        }
        
    }
}
