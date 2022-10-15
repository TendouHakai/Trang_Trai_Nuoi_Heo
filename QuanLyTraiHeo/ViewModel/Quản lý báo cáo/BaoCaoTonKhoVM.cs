using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTraiHeo.ViewModel.BaoCaoThuChiVM;

namespace QuanLyTraiHeo.ViewModel
{
    public class BaoCaoTonKhoVM:BaseViewModel
    {
        public List<HangHoa> LstHangHoa = new List<HangHoa>();
        public List<HangHoa> lstHangHoa { get => LstHangHoa; set { LstHangHoa = value; OnPropertyChanged(); } }
        public BaoCaoTonKhoVM()
        {
            #region binding dữ liệu cho danh sách hàng hoá trong kho
            lstHangHoa.Add(new HangHoa() { STT = "1", IDHangHoa = "TA01", TenHangHoa = "Thức ăn HH cao cấp cho heo nái mang thai 8042", LoaiHangHoa = "Thức ăn", Soluong = "20", DVT = "bao", TonDau = "10", NhapThem = "10" });
            lstHangHoa.Add(new HangHoa() { STT = "2", IDHangHoa = "TA02", TenHangHoa = "B52/AMPI-COL", LoaiHangHoa = "Thuốc", Soluong = "50", DVT = "chai", TonDau = "5", NhapThem = "45" });
            lstHangHoa.Add(new HangHoa() { STT = "", IDHangHoa = "", TenHangHoa = "TỔNG SỐ LƯỢNG", LoaiHangHoa = "", Soluong = "70", DVT = "", TonDau = "", NhapThem = "" });
            #endregion
        }

        public class HangHoa
        {
            public string STT { get; set; }
            public string IDHangHoa { get; set; }
            public string TenHangHoa { get; set; }
            public string LoaiHangHoa { get; set; }
            public string Soluong { get; set; }
            public string DVT { get; set; }
            public string TonDau { get; set; }
            public string NhapThem { get; set; }
        }
    }
}
