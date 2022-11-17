using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyTraiHeo.ViewModel
{
    public class ThemPhieuSuaChuaVM : BaseViewModel
    {
        #region Attributes
        List<PHIEUSUACHUA> _PhieuSuaChua = new List<PHIEUSUACHUA>();
        private ObservableCollection<PHIEUSUACHUA> pHIEUSUACHUAs;
        string _MaNhanVien = "";
        string _TenDoiTac = "";
        string _NgaySuaChua = "";
        string _GhiChu = "";
        string _TrangThai = "";
        string _TongTien = "";
        #endregion

        #region Property
        public List<PHIEUSUACHUA> PhieuSuaChua { get => _PhieuSuaChua; set { _PhieuSuaChua = value; OnPropertyChanged(); } }
        public string MaNhanVien { get => _MaNhanVien; set { _MaNhanVien = value; OnPropertyChanged(); } }
        public string NgaySuaChua { get => _NgaySuaChua; set { _NgaySuaChua = value; OnPropertyChanged(); } }
        public string GhiChu { get => _GhiChu; set { _GhiChu = value; OnPropertyChanged(); } }
        public string TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }
        public string TongTien { get => _TongTien; set { _TongTien = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand ThemCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        #endregion

        public ThemPhieuSuaChuaVM()
        {
            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                foreach (var item in _PhieuSuaChua)
                {
                    DataProvider.Ins.DB.PHIEUSUACHUAs.Add(item);
                }
                DataProvider.Ins.DB.SaveChanges();
                _PhieuSuaChua.Clear();
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();
            });
            ThemCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                var phieuSuaChua = new PHIEUSUACHUA() { MaNhanVien = MaNhanVien, MaDoiTac = _TenDoiTac., NgaySuaChua = DateTime.Parse(NgaySuaChua), GhiChu = GhiChu, TrangThai = TrangThai, TongTien = Convert.ToInt32(TongTien) };
                _PhieuSuaChua.Add(phieuSuaChua);
                p.Items.Refresh();
            });
        }
    }
}
