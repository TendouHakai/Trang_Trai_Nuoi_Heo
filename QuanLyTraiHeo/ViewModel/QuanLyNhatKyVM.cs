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
using System.Windows.Data;
using System.Data.Entity.Core.Objects;
using System.ComponentModel;
using System.Data.Entity;

namespace QuanLyTraiHeo.ViewModel
{

    public class QuanLyNhatKyVM : BaseViewModel
    {
        #region Atributes
        private int selectedPage { get; set; }
        private int totalPage { get; set; }
        private int rowPerPage = 5;
        public ObservableCollection<NhatKy> listNhatKy { get; set; }
        private List<NhatKy> tempListNhatKy;
        public ObservableCollection<HanhDong> lstHanhDong { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }

        #endregion

        #region Properties
        public int SelectedPage { get => this.selectedPage; set { this.selectedPage = value; OnPropertyChanged(); } }
        public int TotalPage { get =>this.totalPage;  set { this.totalPage = value; OnPropertyChanged(); } }

        #endregion

        #region EventCommand
        public ICommand TimKiemCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand LastPageCommand { get; set; }
        public ICommand FirstPageCommand { get; set; }
        public ICommand SelectPageChangedCommand { get; set; }

        #endregion
        public QuanLyNhatKyVM()
        {
            SelectedPage = 1;
            TotalPage = 1;
            listNhatKy = new ObservableCollection<NhatKy>();
            tempListNhatKy = new List<NhatKy>();
            lstHanhDong = new ObservableCollection<HanhDong>();
            lstHanhDong.Add(new HanhDong(true, "Nhập, xuất kho"));
            lstHanhDong.Add(new HanhDong(true, "Kiểm kho"));
            lstHanhDong.Add(new HanhDong(true, "Nhập, xuất heo"));
            lstHanhDong.Add(new HanhDong(true, "Tiêm heo"));
            lstHanhDong.Add(new HanhDong(true, "Phối giống heo"));
            lstHanhDong.Add(new HanhDong(true, "Sửa chữa"));
            DenNgay = DateTime.Today;
            TuNgay = DenNgay;
            //LoadListHanhDong(null);
            TimKiemCommand = new RelayCommand<ListView>((p) => { return true; }, p => 
            { 
                LoadListHanhDong(); 
                SelectPageChanged(p); 
            });
            PreviousPageCommand = new RelayCommand<ListView>((p) => { return true; }, p =>
            {
                SelectedPage = SelectedPage - 1;
                SelectPageChanged(p);
            });
            LastPageCommand = new RelayCommand<ListView>((p) => { return true; }, p =>
            {
                SelectedPage = TotalPage;
                SelectPageChanged(p);
            });
            FirstPageCommand = new RelayCommand<ListView>((p) => { return true; }, p =>
            {
                SelectedPage = 1;
                SelectPageChanged(p);
            });
            NextPageCommand = new RelayCommand<ListView>((p) => { return true; }, p =>
            {
                SelectedPage = SelectedPage + 1;
                SelectPageChanged(p);
            });
           SelectPageChangedCommand = new RelayCommand<ListView>((p) => { return true; }, p => {  SelectPageChanged(p);});

        }

        #region Method
        private void SelectPageChanged(ListView p)
        {
            if (SelectedPage < 1 )
                SelectedPage = 1;
            if (SelectedPage > TotalPage)
                SelectedPage = TotalPage;
            listNhatKy.Clear();
            for (int i = (SelectedPage - 1) * rowPerPage; i < tempListNhatKy.Count() && i < SelectedPage * rowPerPage; i++)
            {
                listNhatKy.Add(tempListNhatKy[i]);
            }
            if (p != null)
            {
                p.Items.GroupDescriptions.Clear();
                p.Items.GroupDescriptions.Add(new PropertyGroupDescription("Ngay"));
                //p.Items.SortDescriptions.Add(new SortDescription("ThoiGian", ListSortDirection.Descending));     
            }
        }
        private void LoadListHanhDong()
        {
            listNhatKy.Clear();

            tempListNhatKy.Clear();
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

            SelectedPage = 1;

            if (tempListNhatKy.Count() % rowPerPage > 0)
                TotalPage = tempListNhatKy.Count() / rowPerPage + 1;
            else
                TotalPage = tempListNhatKy.Count() / rowPerPage ;

            if (TotalPage == 0)
                TotalPage = 1;
            tempListNhatKy = tempListNhatKy.OrderByDescending(x => x.ThoiGian).ToList();

        }
        private void LoadPhieuHangHoa()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHANGHOAs
                               //                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)

                           select Phieu

                           ).AsEnumerable()

                           .Select(p => new NhatKy
                           {
                               icon = "Warehouse",
                               TenNhanVien = p.NHANVIEN.HoTen,
                               MaPhieu = p.SoPhieu,
                               Ngay = "Ngày" + p.NgayLap.Value.ToString(" dd/MM/yyyy"),
                               ThoiGian = (DateTime)p.NgayLap,
                               HanhDong = "Vừa tạo 1 phiếu " + p.LoaiPhieu.ToString() + " trị giá " + p.TongTien + "VNĐ"
                           }).ToList();
            foreach (var item in Dataset)
                tempListNhatKy.Add(item);
        }
        private void LoadPhieuSuaChua()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUSUACHUAs
                               //where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select Phieu).AsEnumerable()
                           .Select(p => new NhatKy
                           {
                               icon = "Warehouse",
                               TenNhanVien = p.NHANVIEN.HoTen,

                               MaPhieu = p.SoPhieu,
                               Ngay = "Ngày" + p.NgaySuaChua.Value.ToString(" dd/MM/yyyy"),

                               ThoiGian = (DateTime)p.NgaySuaChua,
                               HanhDong = "Sữa chữa chuồng, chi phí " + p.TongTien.ToString() + "VNĐ"

                           }).ToList();
            foreach (var item in Dataset)
                listNhatKy.Add(item);
        }
        private void LoadPhieuKiemKho()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUKIEMKHOes
                               //where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select Phieu).AsEnumerable()
                           .Select(p => new NhatKy
                           {
                               icon = "Warehouse",
                               TenNhanVien = p.NHANVIEN.HoTen,

                               MaPhieu = p.SoPhieu,
                               ThoiGian = (DateTime)p.NgayLap,
                               Ngay = "Ngày" + p.NgayLap.Value.ToString(" dd/MM/yyyy"),

                               HanhDong = "Vừa kiểm kho, kết quả : " + p.KetQua.ToString()

                           }).ToList();
            foreach (var item in Dataset)
                listNhatKy.Add(item);
        }
        private void LoadPhieuHeo()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.PHIEUHEOs
                               //                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select Phieu).AsEnumerable()
                           .Select(p => new NhatKy
                           {
                               icon = "Warehouse",
                               TenNhanVien = p.NHANVIEN.HoTen,
                               Ngay = "Ngày" + p.NgayLap.Value.ToString(" dd/MM/yyyy"),

                               MaPhieu = p.SoPhieu,
                               ThoiGian = (DateTime)p.NgayLap,
                               HanhDong = "Vừa " + p.LoaiPhieu.ToString() + ", trị giá " + p.TongTien + "VNĐ"
                           }).ToList();
            foreach (var item in Dataset)
                listNhatKy.Add(item);
        }
        private void LoadPhieuTiemHeo()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.LICHTIEMHEOs
                               //                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select Phieu).AsEnumerable()
                           .Select(p => new NhatKy
                           {
                               //Ngay = "Ngày" + p.NgayLap.Value.ToString(" dd/MM/yyyy"),

                               icon = "Warehouse",
                               MaPhieu = p.MaLichTiem,
                               HanhDong = "Lên lịch tiêm heo ngày : " + p.NgayTiem.ToString()
                           }).ToList();
            foreach (var item in Dataset)
                listNhatKy.Add(item);
        }
        private void LoadPhieuPhoiGiong()
        {
            var Dataset = (from Phieu in DataProvider.Ins.DB.LICHPHOIGIONGs
                               //                           where (Phieu.NgayLap >= TuNgay && Phieu.NgayLap <= DenNgay)
                           select Phieu).AsEnumerable()
                           .Select(p => new NhatKy
                           {
                               icon = "Warehouse",
                               MaPhieu = p.MaLichPhoi,
                               HanhDong = "tạo phiếu phối giống",
                               //Ngay = "Ngày" + p.NgayLap.Value.ToString(" dd/MM/yyyy")

                           }).ToList();
            foreach (var item in Dataset)
                listNhatKy.Add(item);

        }
        #endregion
    }
}
