using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTraiHeo.ViewModel.BaoCaoTinhTrangHeoVM;

namespace QuanLyTraiHeo.ViewModel
{
    public class BaoCaoSuaChuaVM:BaseViewModel
    {
        private Func<ChartPoint, string> pointLabel;
        public Func<ChartPoint, string> PointLabel { get => pointLabel; set { pointLabel = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollectionTSheoChart { get; set; }
        public string[] LabelsTSheoChart { get; set; }
        public List<Phieu> LstPhieu = new List<Phieu>();
        public List<Phieu> lstPhieu { get=>LstPhieu; set { LstPhieu = value; OnPropertyChanged(); } }
        public BaoCaoSuaChuaVM()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            #region binding dữ liệu cho Biểu đồ tổng số chuồng trại đã sửa chửa
            SeriesCollectionTSheoChart = new SeriesCollection
            {
                new LineSeries
                {
                    Title ="Chuồng đã sửa chữa",
                    Values = new ChartValues<double> { 3, 2, 11, 5 ,4, 22, 13, 11, 55, 4, 4, 33 }
                }
            };

            LabelsTSheoChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            #endregion
            #region binding dữ liệu cho danh sách phiếu
            lstPhieu.Add(new Phieu() { STT = "1", IDPhieu = "SP01", IDChuong = "CH01", Ngay = "13/11/2022", NhanVien = "Trần Trung Thành", TongTien = "100,000 VND", Ghichu = "Hư 1 đèn sưởi" });
            lstPhieu.Add(new Phieu() { STT = "", IDPhieu = "", IDChuong = "", Ngay = "", NhanVien = "TỔNG TIỀN", TongTien = "100,000 VND", Ghichu = "" });
            #endregion
        }
        public class Phieu
        {
            public string STT { get; set; }
            public string IDPhieu { get; set; }
            public string IDChuong { get; set; }
            public string Ngay { get; set; }
            public string NhanVien { get; set; }
            public string TongTien { get; set; }
            public string Ghichu { get; set; }
        }
    }
    
}
