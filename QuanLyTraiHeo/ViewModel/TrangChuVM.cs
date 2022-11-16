using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MaterialDesignColors;
using QuanLyTraiHeo.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using static QuanLyTraiHeo.ViewModel.BaoCaoSuaChuaVM;

namespace QuanLyTraiHeo.ViewModel
{
    public class TrangChuVM:BaseViewModel
    {
        private Func<ChartPoint, string> pointLabel;
        public Func<ChartPoint, string> PointLabel { get => pointLabel; set { pointLabel = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollectionDSCPChart { get; set; }
        public string[] LabelsDSCPChart { get; set; }
        public SeriesCollection SeriesCollectionNVChart { get; set; }
        public string[] LabelsNVChart { get; set; }

        private List<int> _listNamPieChartCoCauHeo;
        public List<int> listNamPieChartCoCauHeo { get => _listNamPieChartCoCauHeo; set { _listNamPieChartCoCauHeo = value; OnPropertyChanged(); } }

        private List<int> _listNamPieChartCoCauChuong;
        public List<int> listNamPieChartCoCauChuong { get => _listNamPieChartCoCauChuong; set { _listNamPieChartCoCauChuong = value; OnPropertyChanged(); } }

        private List<int> _listNamColumnChartDoanhThuChiTieu;
        public List<int> listNamColumnChartDoanhThuChiTieu { get => _listNamColumnChartDoanhThuChiTieu; set { _listNamColumnChartDoanhThuChiTieu = value; OnPropertyChanged(); } }

        private int _SoLuongHeoTot;
        public int SoLuongHeoTot { get => _SoLuongHeoTot; set { _SoLuongHeoTot = value; OnPropertyChanged(); }  }

        private float _PhanTramHeoTot;
        public float PhanTramHeoTot { get => _PhanTramHeoTot; set { _PhanTramHeoTot = value; OnPropertyChanged(); } }

        private int _SoLuongHeoBenhChet;
        public int SoLuongHeoBenhChet { get => _SoLuongHeoBenhChet; set { _SoLuongHeoBenhChet = value; OnPropertyChanged();} }

        private float _PhanTramHeoBenhChet;
        public float PhanTramHeoBenhChet { get => _PhanTramHeoBenhChet; set { _PhanTramHeoBenhChet = value; OnPropertyChanged();} }

        private int _SoLuongChuongHong;
        public int SoLuongChuongHong { get => _SoLuongChuongHong; set { _SoLuongChuongHong = value; OnPropertyChanged();} }

        private float _PhanTramChuongHong;
        public float PhanTramChuongHong { get => _PhanTramChuongHong; set { _PhanTramChuongHong = value; OnPropertyChanged();} }

        private int Doanhthutrongngay;
        private string _DoanhThuTrongNgay;
        public string DoanhThuTrongNgay { get => _DoanhThuTrongNgay; set { _DoanhThuTrongNgay = value; OnPropertyChanged();} }

        private float _TangTruongDoanhThu;
        public float TangTruongDoanhThu { get => _TangTruongDoanhThu; set { _TangTruongDoanhThu = value; OnPropertyChanged();} }

        private int Chitieutrongngay;
        private string _ChiTieuTrongNgay;
        public string ChiTieuTrongNgay { get => _ChiTieuTrongNgay; set { _ChiTieuTrongNgay = value; OnPropertyChanged();} }

        private float _SuyGiamChiPhi;
        public float SuyGiamChiPhi { get => _SuyGiamChiPhi; set { _SuyGiamChiPhi = value; OnPropertyChanged();} }

        private SeriesCollection _SeriesCoCauHeo;
        public SeriesCollection SeriesCoCauHeo { get => _SeriesCoCauHeo; set { _SeriesCoCauHeo = value; OnPropertyChanged();} }

        private SeriesCollection _SeriesCoCauChuong;
        public SeriesCollection SeriesCoCauChuong { get => _SeriesCoCauChuong; set { _SeriesCoCauChuong = value; OnPropertyChanged(); } }


        //public List<HoatDong> LstHoatDong = new List<HoatDong>();
        //public List<HoatDong> lstHoatDong { get => LstHoatDong; set { LstHoatDong = value; OnPropertyChanged(); } }
        public TrangChuVM()
        {
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCoCauHeo = new SeriesCollection();
            SeriesCoCauChuong = new SeriesCollection();
            SeriesCollectionDSCPChart = new SeriesCollection();
            SeriesCollectionNVChart = new SeriesCollection();
            listNamPieChartCoCauHeo = new List<int>();
            listNamPieChartCoCauChuong = new List<int>();
            listNamColumnChartDoanhThuChiTieu = new List<int>();

            #region Khởi tạo list năm cho PieChart Cơ cấu heo
            listNamPieChartCoCauHeo = DataProvider.Ins.DB.HEOs.Select(x => x.NgaySinh.Value.Year).Distinct().ToList();
            #endregion

            #region Khởi tạo list năm cho PieChart Cơ cấu chuồng
            //listNamPieChartCoCauChuong = DataProvider.Ins.DB.CHUONGTRAIs.Select(x=>x.)
            #endregion

            #region Khởi tạo list năm cho ColumnChart Doanh thu chi tiêu
            var listNamColumnChartDoanhThuChiTieuTheoPhieuHeo = DataProvider.Ins.DB.PHIEUHEOs.Select(x => x.NgayLap.Value.Year).Distinct().ToList();
            var listNamColumnChartDoanhThuChiTieuTheoPhieuSuaChua = DataProvider.Ins.DB.PHIEUSUACHUAs.Select(x => x.NgaySuaChua.Value.Year).Distinct().ToList();
            var listNamColumnChartDoanhThuChiTieuTheoPhieuHangHoa = DataProvider.Ins.DB.PHIEUHANGHOAs.Select(x => x.NgayLap.Value.Year).Distinct().ToList();

            foreach(var item in listNamColumnChartDoanhThuChiTieuTheoPhieuHeo)
            {
                listNamColumnChartDoanhThuChiTieu.Add(item);
            }
            foreach (var item in listNamColumnChartDoanhThuChiTieuTheoPhieuSuaChua)
            {
                listNamColumnChartDoanhThuChiTieu.Add(item);
            }
            foreach (var item in listNamColumnChartDoanhThuChiTieuTheoPhieuHangHoa)
            {
                listNamColumnChartDoanhThuChiTieu.Add(item);
            }

            listNamColumnChartDoanhThuChiTieu = listNamColumnChartDoanhThuChiTieu.Distinct().ToList();

            #endregion

            LoadDSThongSo();
            loadPieChartCoCauHeo();
            loadPieChartCoCauChuong();
            loadLineChartDoanhThuChiTieu();
            loadColumnChartNhanVien();

            //#region Binding dữ liệu lên biểu đồ doanh thu và chi phí trong ngày
            //SeriesCollectionDSCPChart = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title ="Doanh thu",
            //        Values = new ChartValues<double> { 35, 23, 41, 55 ,48, 62, 63, 41, 55, 44, 41, 33 }
            //    },
            //    new LineSeries
            //    {
            //        Title ="Chi phí",
            //        Values = new ChartValues<double> { 13, 12, 11, 15 ,14, 22, 13, 11, 25, 24, 14, 13 }
            //    }
            //};

            //LabelsDSCPChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            //#endregion

            //#region binding dữ liệu cho danh sách hoạt động
            //lstHoatDong.Add(new HoatDong() { icon = "Warehouse",  TenNhanVien = "Trần Trung Thành", Mota = "Thực hiện một phiếu nhập kho trị giá 3,000,000 VND", MaPhieu = "SP01"});
            //lstHoatDong.Add(new HoatDong() { icon = "Warehouse", TenNhanVien = "", Mota = "", MaPhieu = "" });
            //#endregion
        }

        void loadSoLuongHeoTot()
        {
            SoLuongHeoTot = DataProvider.Ins.DB.HEOs.Where(x => x.TinhTrang == "Sức khoẻ tốt").Count();
        }
        void loadPhanTramHeoTot()
        {
            var TongSoheo = DataProvider.Ins.DB.HEOs.Count();
            if(TongSoheo > 0)
                PhanTramHeoTot = SoLuongHeoTot * 100 / TongSoheo;
            else
                PhanTramHeoTot = 0;
        }
        void loadSoLuongHeoBenhChet()
        {
            SoLuongHeoBenhChet = DataProvider.Ins.DB.HEOs.Where(x => x.TinhTrang == "Đang bị bệnh" || x.TinhTrang == "Đã chết").Count();
        }
        void loadPhanTramHeoBenhChet()
        {
            var TongSoheo = DataProvider.Ins.DB.HEOs.Count();
            if(TongSoheo > 0)
                PhanTramHeoBenhChet = SoLuongHeoBenhChet*100 / TongSoheo;
            else
                PhanTramHeoBenhChet = 0;
        }
        void loadSoLuongChuongHong()
        {
            SoLuongChuongHong = DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.TinhTrang=="Đang hư hỏng").Count();
        }
        void loadPhanTramHeoChuongHong()
        {
            var TongSoChuong = DataProvider.Ins.DB.CHUONGTRAIs.Count();
            if (TongSoChuong > 0)
                _PhanTramChuongHong = SoLuongChuongHong * 100 / TongSoChuong;
            else _PhanTramChuongHong = 0;
        }
        void LoadDoanhThuTrongNgay()
        {
            Doanhthutrongngay = 0;
            try
            {
                Doanhthutrongngay = int.Parse(DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu xuất ngoại" && x.NgayLap == DateTime.Today && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch(Exception e) { }
            try
            {
                Doanhthutrongngay += int.Parse(DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu xuất ngoại" && x.NgayLap == DateTime.Today && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch(Exception e) { }
            DoanhThuTrongNgay = String.Format("{0:#,##0}", Doanhthutrongngay);
        }
        void loadTangTruongDoanhThu()
        {
            DateTime homqua = DateTime.Today.AddDays(-1);
            int DoanhThuHomQua = 0;
            try
            {
                DoanhThuHomQua = int.Parse(DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu xuất heo" && x.NgayLap == homqua && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch(Exception e) { }
            try
            {
                DoanhThuHomQua += int.Parse(DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu xuất ngoại" && x.NgayLap == homqua && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch (Exception e) { }
            if (DoanhThuHomQua > 0)
                TangTruongDoanhThu = Math.Abs((Doanhthutrongngay - DoanhThuHomQua)*100/DoanhThuHomQua);
            else TangTruongDoanhThu = 0;
        }
        void loadChiPhiTrongNgay()
        {
            Chitieutrongngay = 0;
            try
            {
                Chitieutrongngay = int.Parse(DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu nhập heo" && x.NgayLap == DateTime.Today && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).GetValueOrDefault().ToString());
            }
            catch(Exception e) { }
            try
            {
                Chitieutrongngay += int.Parse(DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu nhập kho" && x.NgayLap == DateTime.Today && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch (Exception e) { }
            ChiTieuTrongNgay = String.Format("{0:#,##0}", Chitieutrongngay);
        }
        void loadSuyGiamChiPhi()
        {
            DateTime homqua = DateTime.Today.AddDays(-1);
            int ChiPhiHomQua = 0;
            try
            {
                ChiPhiHomQua = int.Parse(DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu xuất heo" && x.NgayLap == homqua && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch (Exception e) { }
            try
            {
                ChiPhiHomQua += int.Parse(DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu xuất ngoại" && x.NgayLap == homqua && x.TrangThai == "Đã hoàn thành").Sum(x => x.TongTien).ToString());
            }
            catch(Exception e) { }
            if (ChiPhiHomQua>0)
                SuyGiamChiPhi = Math.Abs((Chitieutrongngay - ChiPhiHomQua) * 100 / ChiPhiHomQua);
            else 
                SuyGiamChiPhi = 0;
        }
        void LoadDSThongSo() 
        {
            loadSoLuongHeoTot();
            loadPhanTramHeoTot();
            loadSoLuongHeoBenhChet();
            loadPhanTramHeoBenhChet();
            loadSoLuongChuongHong();
            loadPhanTramHeoChuongHong();
            LoadDoanhThuTrongNgay();
            loadTangTruongDoanhThu();
            loadChiPhiTrongNgay();
            loadSuyGiamChiPhi();
        }
        void loadPieChartCoCauHeo()
        {
            SeriesCoCauHeo.Clear();
            var listLoaiHeo = DataProvider.Ins.DB.HEOs.GroupBy(x => x.LOAIHEO.TenLoaiHeo).ToList();
            foreach(var item in listLoaiHeo)
            {
                var pieseries = new PieSeries();
                pieseries.Title = item.Key.ToString();
                pieseries.Values = new ChartValues<ObservableValue> { new ObservableValue(item.Count()) };
                pieseries.DataLabels = true;
                pieseries.LabelPoint = PointLabel;

                SeriesCoCauHeo.Add(pieseries);
            }
        }
        void loadPieChartCoCauChuong()
        {
            SeriesCoCauChuong.Clear();
            var listChuongNuoi = DataProvider.Ins.DB.CHUONGTRAIs.GroupBy(x => x.TinhTrang).ToList();
            foreach (var item in listChuongNuoi)
            {
                var pieseries = new PieSeries();
                pieseries.Title = item.Key.ToString();
                pieseries.Values = new ChartValues<ObservableValue> { new ObservableValue(item.Count()) };
                pieseries.DataLabels = true;
                pieseries.LabelPoint = PointLabel;

                SeriesCoCauChuong.Add(pieseries);
            }
        }
        void loadLineChartDoanhThuChiTieu()
        {
            SeriesCollectionDSCPChart.Clear();

            // cài đặt doanh thu
            var lineDoanhThu = new LineSeries();
            lineDoanhThu.Title = "Doanh thu";
            lineDoanhThu.Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            SeriesCollectionDSCPChart.Add(lineDoanhThu);

            var listDoanhThuTheoPhieuHeo = DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu xuất heo" && x.NgayLap.Value.Year == DateTime.Today.Year && x.TrangThai == "Đã hoàn thành").GroupBy(x => x.NgayLap.Value.Month).ToList();
            foreach(var item in listDoanhThuTheoPhieuHeo)
            {
                double Tongtien = double.Parse(lineDoanhThu.Values[item.Key - 1].ToString()) + double.Parse(item.Sum(x => x.TongTien).ToString());
                lineDoanhThu.Values[item.Key - 1] = Tongtien;
            }
            var listDoanhThuTheoPhieuHangHoa = DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu xuất ngoại" && x.NgayLap.Value.Year == DateTime.Today.Year && x.TrangThai == "Đã hoàn thành").GroupBy(x => x.NgayLap.Value.Month).ToList();
            foreach (var item in listDoanhThuTheoPhieuHangHoa)
            {
                double Tongtien = double.Parse(lineDoanhThu.Values[item.Key - 1].ToString()) + double.Parse(item.Sum(x => x.TongTien).ToString());
                lineDoanhThu.Values[item.Key - 1] = Tongtien;
            }
            var listDoanhThuTheoPhieuSuaChua = DataProvider.Ins.DB.PHIEUSUACHUAs.Where(x => x.NgaySuaChua.Value.Year == DateTime.Today.Year && x.TrangThai == "Đã hoàn thành").GroupBy(x => x.NgaySuaChua.Value.Month).ToList();
            foreach(var item in listDoanhThuTheoPhieuSuaChua)
            {
                double Tongtien = double.Parse(lineDoanhThu.Values[item.Key - 1].ToString()) + double.Parse(item.Sum(x => x.TongTien).ToString());
                lineDoanhThu.Values[item.Key - 1] = Tongtien;
            }

            //cài đặt chi tiêu
            var lineChiTieu = new LineSeries();
            lineChiTieu.Title = "Chi tiêu";
            lineChiTieu.Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            SeriesCollectionDSCPChart.Add(lineChiTieu);

            var listChiTieuTheoPhieuHeo = DataProvider.Ins.DB.PHIEUHEOs.Where(x => x.LoaiPhieu == "Phiếu nhập heo" && x.NgayLap.Value.Year == DateTime.Today.Year && x.TrangThai == "Đã hoàn thành").GroupBy(x => x.NgayLap.Value.Month).ToList();
            foreach (var item in listChiTieuTheoPhieuHeo)
            {
                double Tongtien = double.Parse(lineChiTieu.Values[item.Key - 1].ToString()) + double.Parse(item.Sum(x => x.TongTien).ToString());
                lineChiTieu.Values[item.Key - 1] = Tongtien;
            }
            var listChiTieuTheoPhieuHangHoa = DataProvider.Ins.DB.PHIEUHANGHOAs.Where(x => x.LoaiPhieu == "Phiếu nhập kho" && x.NgayLap.Value.Year == DateTime.Today.Year && x.TrangThai == "Đã hoàn thành").GroupBy(x => x.NgayLap.Value.Month).ToList();
            foreach (var item in listChiTieuTheoPhieuHangHoa)
            {
                double Tongtien = double.Parse(lineChiTieu.Values[item.Key - 1].ToString()) + double.Parse(item.Sum(x => x.TongTien).ToString());
                lineChiTieu.Values[item.Key - 1] = Tongtien;
            }

            LabelsDSCPChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        }
        void loadColumnChartNhanVien()
        {
            SeriesCollectionNVChart.Clear();
            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.GroupBy(x => x.CHUCVU.TenChucVu).ToList();
            var row = new RowSeries();
            LabelsNVChart = new string[listNhanVien.Count];
            row.Values = new ChartValues<double>();
            row.Title = "Số nhân viên";
            SeriesCollectionNVChart.Add(row);
            int i = 0;
            foreach (var item in listNhanVien)
            {
                double count = item.Count();
                row.Values.Add(count);
                LabelsNVChart[i] = item.Key.ToString();
                i++;
            }
        }
    }
}
