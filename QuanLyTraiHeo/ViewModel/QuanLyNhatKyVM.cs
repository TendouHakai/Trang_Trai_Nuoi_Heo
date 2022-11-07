using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTraiHeo.Model;
using static QuanLyTraiHeo.ViewModel.TrangChuVM;
using QuanLyTraiHeo.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace QuanLyTraiHeo.ViewModel
{

    public class QuanLyNhatKyVM : BaseViewModel
    {
        public ObservableCollection<HoatDong> LstNhatKy { get; set; }
        public ObservableCollection<HanhDong> lstHanhDong { get; set; }

        public ICommand TimKiemCommand { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public QuanLyNhatKyVM()
        {
            LstNhatKy = new ObservableCollection<HoatDong>();
            lstHanhDong = new ObservableCollection<HanhDong>();
            lstHanhDong.Add(new HanhDong(true, "Nhập, xuất kho"));
            lstHanhDong.Add(new HanhDong(true, "Kiểm kho"));
            lstHanhDong.Add(new HanhDong(true, "Nhập, xuất heo"));
            lstHanhDong.Add(new HanhDong(true, "Tiêm heo"));
            lstHanhDong.Add(new HanhDong(true, "Phối giống heo"));
            lstHanhDong.Add(new HanhDong(true, "Sửa chữa"));

            DenNgay = DateTime.Today;
            TuNgay = DenNgay;
            LoadListHanhDong();

            TimKiemCommand = new RelayCommand<ListView>((p) => { return true; }, p => { LoadListHanhDong(p); });
        }

        private void LoadListHanhDong(ListView p = null)
        {
            LstNhatKy.Clear();

            foreach (var item in lstHanhDong)
            {
                if (item.ischecked == true)
                {
                    switch (item.TenHanhDong)
                    {
                        case "Nhập, xuất kho":
                            LoadPhieuHangHoa();
                            break;
                        case "Kiểm kho":
                            LoadPhieuKiemKho();
                            break;
                        case "Nhập, xuất heo":
                            LoadPhieuHeo();
                            break;
                        case "Tiêm heo":
                            LoadPhieuTiemHeo();
                            break;
                        case "Phối giống heo":
                            LoadPhieuPhoiGiong();
                            break;
                        case "Sửa chữa":
                            LoadPhieuSuaChua();
                            break;
                        default: break;
                    }
                }
            }
        }
        private void LoadPhieuHangHoa()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHANGHOAs
                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select new HoatDong
                           {
                               icon = "Warehouse",
                               TenNhanVien = Phieu.NHANVIEN.HoTen,

                               MaPhieu = Phieu.SoPhieu,
                               ThoiGian = (DateTime)Phieu.NgayLap

                           }).ToList();
            foreach (var item in Dataset)
                LstNhatKy.Add(item);
        }
        private void LoadPhieuSuaChua()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHANGHOAs
                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select new HoatDong
                           {
                               icon = "Warehouse",
                               TenNhanVien = Phieu.NHANVIEN.HoTen,

                               MaPhieu = Phieu.SoPhieu,
                               ThoiGian = (DateTime)Phieu.NgayLap

                           }).ToList();
            foreach (var item in Dataset)
                LstNhatKy.Add(item);
        }
        private void LoadPhieuKiemKho()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHANGHOAs
                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select new HoatDong
                           {
                               icon = "Warehouse",
                               TenNhanVien = Phieu.NHANVIEN.HoTen,

                               MaPhieu = Phieu.SoPhieu,
                               ThoiGian = (DateTime)Phieu.NgayLap

                           }).ToList();
            foreach (var item in Dataset)
                LstNhatKy.Add(item);
        }
        private void LoadPhieuHeo()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHANGHOAs
                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select new HoatDong
                           {
                               icon = "Warehouse",
                               TenNhanVien = Phieu.NHANVIEN.HoTen,

                               MaPhieu = Phieu.SoPhieu,
                               ThoiGian = (DateTime)Phieu.NgayLap

                           }).ToList();
            foreach (var item in Dataset)
                LstNhatKy.Add(item);
        }
        private void LoadPhieuTiemHeo()
        {

        }
        private void LoadPhieuPhoiGiong()
        {

        }
    }
}
