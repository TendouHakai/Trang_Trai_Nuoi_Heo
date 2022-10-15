using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTraiHeo.ViewModel.BaoCaoSuaChuaVM;

namespace QuanLyTraiHeo.ViewModel
{
    public class BaoCaoThuChiVM: BaseViewModel
    {
        private Func<ChartPoint, string> pointLabel;
        public Func<ChartPoint, string> PointLabel { get => pointLabel; set { pointLabel = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollectionTCChart { get; set; }
        public string[] LabelsTCChart { get; set; }
        public List<PhieuThuChi> LstPhieuThuChi = new List<PhieuThuChi>();
        public List<PhieuThuChi> lstPhieuThuChi { get => LstPhieuThuChi; set { LstPhieuThuChi = value; OnPropertyChanged(); } }
        public BaoCaoThuChiVM()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            #region binding dữ liệu cho Biểu đồ doanh thu và chi phí
            SeriesCollectionTCChart = new SeriesCollection
            {
                new LineSeries
                {
                    Title ="Doanh thu",
                    Values = new ChartValues<double> { 35, 23, 41, 55 ,48, 62, 63, 41, 55, 44, 41, 33 }
                },
                new LineSeries
                {
                    Title ="Chi phí",
                    Values = new ChartValues<double> { 13, 12, 11, 15 ,14, 22, 13, 11, 25, 24, 14, 13 }
                }
            };
            LabelsTCChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            #endregion
            #region binding dữ liệu cho danh sách phiếu
            lstPhieuThuChi.Add(new PhieuThuChi() { STT = "1", IDPhieu = "SP01", Ngay = "13/11/2022", NhanVien = "Trần Trung Thành", DoiTac = "Công ty thực phẩm Thành An", TongTien = "100,000 VND" });
            lstPhieuThuChi.Add(new PhieuThuChi() { STT = "", IDPhieu = "", Ngay = "", NhanVien = "TỔNG THU", DoiTac = "", TongTien = "100,000 VND" });
            lstPhieuThuChi.Add(new PhieuThuChi() { STT = "", IDPhieu = "", Ngay = "", NhanVien = "TỔNG CHI", DoiTac = "", TongTien = "0  VND" });
            #endregion

        }

        public class PhieuThuChi
        {
            public string STT { get; set; }
            public string IDPhieu { get; set; }
            public string Ngay { get; set; }
            public string NhanVien { get; set; }
            public string DoiTac { get; set; }
            public string TongTien { get; set; }
        }
    }
}
