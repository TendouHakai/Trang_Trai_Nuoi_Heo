using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTraiHeo.ViewModel.TrangChuVM;

namespace QuanLyTraiHeo.ViewModel
{
    public class QuanLyNhatKyVM: BaseViewModel
    {
        public List<HoatDong> LstNhatKy = new List<HoatDong>();
        public List<HoatDong> lstNhatKy { get => LstNhatKy; set { LstNhatKy = value; OnPropertyChanged(); } }

        public QuanLyNhatKyVM()
        {
            #region Binding dữ liệu ngày 
            lstNhatKy.Add(new HoatDong() { icon = "Warehouse", TenNhanVien = "Trần Trung Thành", Mota = "Thực hiện một phiếu nhập kho trị giá 3,000,000 VND", MaPhieu = "SP01" });
            lstNhatKy.Add(new HoatDong() { icon = "CurrencyUsd", TenNhanVien = "Triệu Tuấn Tú", Mota = "Thực hiện một phiếu bán heo trị giá 50,000,000 VND", MaPhieu = "SP02" });
            #endregion
        }
    }
}
