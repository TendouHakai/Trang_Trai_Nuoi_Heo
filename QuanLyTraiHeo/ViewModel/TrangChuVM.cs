using LiveCharts;
using LiveCharts.Wpf;
using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        //public List<HoatDong> LstHoatDong = new List<HoatDong>();
        //public List<HoatDong> lstHoatDong { get => LstHoatDong; set { LstHoatDong = value; OnPropertyChanged(); } }
        public TrangChuVM()
        {
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            #region Binding dữ liệu lên biểu đồ doanh thu và chi phí trong ngày
            SeriesCollectionDSCPChart = new SeriesCollection
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

            LabelsDSCPChart = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            #endregion

            #region Binding dữ liệu biểu đồ cơ cấu nhân viên
            SeriesCollectionNVChart = new SeriesCollection
            {
                new RowSeries
                {
                    Title ="Số nhân viên",
                    Values = new ChartValues<double> { 1, 50, 10, 2, 4 }
                }
            };

            LabelsNVChart = new[] { "Quản lý", "Nhân viên chăm sóc", "Nhân viên kỹ thuật", "Nhân viên sửa chữa", "Nhân viên kế toán", "Nhân viên kho"};
            #endregion

            //#region binding dữ liệu cho danh sách hoạt động
            //lstHoatDong.Add(new HoatDong() { icon = "Warehouse",  TenNhanVien = "Trần Trung Thành", Mota = "Thực hiện một phiếu nhập kho trị giá 3,000,000 VND", MaPhieu = "SP01"});
            //lstHoatDong.Add(new HoatDong() { icon = "Warehouse", TenNhanVien = "", Mota = "", MaPhieu = "" });
            //#endregion
        }

    }
}
