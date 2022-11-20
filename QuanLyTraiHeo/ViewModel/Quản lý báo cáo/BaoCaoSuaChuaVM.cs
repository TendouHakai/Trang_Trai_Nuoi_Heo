using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using OfficeOpenXml;
using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static QuanLyTraiHeo.ViewModel.BaoCaoTinhTrangHeoVM;
using LicenseContext = OfficeOpenXml.LicenseContext;
using SeriesCollection = LiveCharts.SeriesCollection;
using System.Windows.Controls;
using DataTable = System.Data.DataTable;
using System.Windows.Data;
using OfficeOpenXml.Style;

namespace QuanLyTraiHeo.ViewModel
{
    public class BaoCaoSuaChuaVM : BaseViewModel
    {
        #region Attributes
        private Func<ChartPoint, string> pointLabel;
        public List<PHIEUSUACHUA> lstPhieu = new List<PHIEUSUACHUA>();
        private DataTable table = new DataTable(DataProvider.Ins.DB.PHIEUSUACHUAs.Sql);
        public DataGrid dataGrid = new DataGrid();
        #endregion

        #region Property
        public Func<ChartPoint, string> PointLabel { get => pointLabel; set { pointLabel = value; OnPropertyChanged(); } }
        public List<PHIEUSUACHUA> LstPhieu { get => lstPhieu; set { lstPhieu = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollectionTSheoChart { get; set; }
        public string[] LabelsTSheoChart { get; set; }
        #endregion

        #region Command
        public ICommand XuatFileExcelCommand { get; set; }
        #endregion

        public BaoCaoSuaChuaVM()
        {
            LstPhieu = DataProvider.Ins.DB.PHIEUSUACHUAs.ToList();
            DataSet temp = new DataSet();
            dataGrid.ItemsSource = table.DefaultView;
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
            XuatFileExcelCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                string filePath = "";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Excel | *.xlsx";
                if(dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                }
                if(string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn không hợp lệ!");
                    return;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                try
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        excelPackage.Workbook.Properties.Author = "Dang Khoa";
                        excelPackage.Workbook.Properties.Title = "Báo cáo sửa chữa";
                        excelPackage.Workbook.Worksheets.Add("Báo cáo");
                        ExcelWorksheet ws = excelPackage.Workbook.Worksheets[0];
                        ws.Name = "Báo cáo";
                        ws.Cells.Style.Font.Size = 15;
                        ws.Cells.Style.Font.Name = "Times New Roman";
                        string[] arrColumnHeader = {
                            "Số phiếu",
                            "Ngày lập phiếu",
                            "Mã nhân viên",
                            "Mã đối tác",
                            "Ghi chú",
                            "Trạng thái",
                            "Tổng tiền"
                        };
                        var countColHeader = arrColumnHeader.Count();
                        ws.Cells[1, 1].Value = "Báo cáo sửa chữa";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        int colIndex = 1;
                        int rowIndex = 2; 
                        foreach(var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];
                            var fill = cell.Style.Fill;
                            var x = cell.Style.WrapText;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            var border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                            cell.Value = item;
                            colIndex++;
                        }
                        foreach(var item in LstPhieu)
                        {
                            colIndex = 1;
                            rowIndex++;
                            ws.Cells[rowIndex, colIndex++].Value = item.SoPhieu.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.NgaySuaChua.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.MaNhanVien.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.MaDoiTac.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.GhiChu.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.TrangThai.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.TongTien.ToString();
                        }
                        Byte[] bin = excelPackage.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất file excel thành công!");
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi xuất file excel!");
                }
            });
        }
    }

}
