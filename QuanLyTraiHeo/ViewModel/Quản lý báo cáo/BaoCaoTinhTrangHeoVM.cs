using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using static QuanLyTraiHeo.ViewModel.BaoCaoTinhTrangHeoVM;
using static QuanLyTraiHeo.ViewModel.BaoCaoTonKhoVM;

namespace QuanLyTraiHeo.ViewModel
{
     public class BaoCaoTinhTrangHeoVM:BaseViewModel
    {
        private Func<ChartPoint, string> pointLabel;
        public Func<ChartPoint, string> PointLabel { get => pointLabel; set { pointLabel = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollectionTSheoChart { get; set; }
        public string[] LabelsTSheoChart { get; set; }
        public List<Heo> LstTinhTrangHeo = new List<Heo>();
        public List<Heo> lstTinhTrangHeo { get => LstTinhTrangHeo; set { LstTinhTrangHeo = value; OnPropertyChanged(); } }
        public BaoCaoTinhTrangHeoVM()
        {
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            #region binding dữ liệu cho Biểu đồ tổng số heo và số heo chết
            SeriesCollectionTSheoChart = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Tổng số heo",
                    Values = new ChartValues<double> { 300, 286, 311, 255 ,304, 322, 213, 311, 255, 304, 344, 333 }
                },
                new LineSeries
                {
                    Title = "Số heo chết",
                    Values = new ChartValues<double> { 20, 30, 33, 12 ,34, 20, 30, 33, 12 ,34, 11, 22 }
                }
            };

            LabelsTSheoChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10","11", "12" };
            #endregion
            #region Binding dữ liệu bảng chi tiết heo
            LstTinhTrangHeo.Add(new Heo() { STT = "1", IDHeo = "HE01", Loaiheo = "Heo nái", Giongheo = "Móng Cái", NgayNhap = "13/11/2022", TinhTrang = "Tốt", NguonGoc = "Heo nhập", TrongLuong = "100" });
            LstTinhTrangHeo.Add(new Heo() { STT = "2", IDHeo = "HE02", Loaiheo = "Heo thịt", Giongheo = "Ỉ", NgayNhap = "01/02/2022", TinhTrang = "Bệnh", NguonGoc = "Heo nhà", TrongLuong = "65" });
            LstTinhTrangHeo.Add(new Heo() { STT = "", IDHeo = "", Loaiheo = "TỔNG SỐ HEO", Giongheo = "", NgayNhap = "2", TinhTrang = "", NguonGoc = "", TrongLuong = "" });
            LstTinhTrangHeo.Add(new Heo() { STT = "", IDHeo = "", Loaiheo = "TỔNG SỐ HEO CHẾT HOẶC BỊ LOẠI THẢI", Giongheo = "", NgayNhap = "0", TinhTrang = "", NguonGoc = "", TrongLuong = "" });
            LstTinhTrangHeo.Add(new Heo() { STT = "", IDHeo = "", Loaiheo = "TỔNG SỐ HEO BỆNH", Giongheo = "", NgayNhap = "1", TinhTrang = "", NguonGoc = "", TrongLuong = "" });
            LstTinhTrangHeo.Add(new Heo() { STT = "", IDHeo = "", Loaiheo = "TỔNG SỐ HEO CHỌN", Giongheo = "", NgayNhap = "1", TinhTrang = "", NguonGoc = "", TrongLuong = "" });
            #endregion

        }
        public class Heo
        {
            public string STT { get; set; }
            public string IDHeo { get; set; }
            public string Loaiheo { get; set; }
            public string Giongheo { get; set; }
            public string NgayNhap { get; set; }
            public string TinhTrang { get; set; }
            public string NguonGoc { get; set; }
            public string TrongLuong { get; set; }
        }

    }
}
