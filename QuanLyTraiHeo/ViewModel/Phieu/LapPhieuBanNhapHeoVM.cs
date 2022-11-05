using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyTraiHeo.View.Windows.Quản_lý_đàn_heo;


namespace QuanLyTraiHeo.ViewModel
{
    public class LapPhieuBanNhapHeoVM : BaseViewModel
    {
        public ObservableCollection<PHIEUHEO> ListPhieuNhap { get; set; }
        public ObservableCollection<PHIEUHEO> ListPhieuXuat { get; set; }


        public ICommand TaoPhieuCommand { get; }
        public LapPhieuBanNhapHeoVM()
        {
            ListPhieuNhap = new ObservableCollection<PHIEUHEO>(DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu nhập"));
            ListPhieuXuat = new ObservableCollection<PHIEUHEO>(DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu xuất"));


            TaoPhieuCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                PhieuNhapBanHeo PhieuNhapBanHeo = new PhieuNhapBanHeo();
                PhieuNhapBanHeo.ShowDialog();
            });
        }
    }
}
