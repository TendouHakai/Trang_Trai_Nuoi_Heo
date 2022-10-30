using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraiHeo.ViewModel
{
    public class ThongTinChuongVM : BaseViewModel
    {
        #region Attributes
        CHUONGTRAI _cHUONGTRAI = new CHUONGTRAI();
        #endregion

        #region Property
        public CHUONGTRAI ChuongTrai { get => _cHUONGTRAI; set { _cHUONGTRAI = value; OnPropertyChanged(); } }
        #endregion

        public ThongTinChuongVM(CHUONGTRAI cHUONGTRAI)
        {
            ChuongTrai.MaChuong = cHUONGTRAI.MaChuong;
            ChuongTrai.MaLoaiChuong = cHUONGTRAI.MaLoaiChuong;
            ChuongTrai.TinhTrang = cHUONGTRAI.TinhTrang;
            ChuongTrai.SuaChuaToiDa = cHUONGTRAI.SuaChuaToiDa;
            ChuongTrai.SoLuongHeo = cHUONGTRAI.SoLuongHeo;
        }
    }
}
