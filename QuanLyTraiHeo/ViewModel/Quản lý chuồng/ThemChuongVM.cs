using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using QuanLyTraiHeo.View.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using static QuanLyTraiHeo.ViewModel.BaoCaoTinhTrangHeoVM;
using System.Collections.ObjectModel;

namespace QuanLyTraiHeo.ViewModel
{
    public class ThemChuongVM : BaseViewModel
    {
        #region Attributes
        List<CHUONGTRAI> _ChuongTrais = new List<CHUONGTRAI>();
        string _MaChuong;
        string _MaLoaiChuong;
        string _TinhTrang;
        int _SucChuaToiDa;
        int _SoLuongHeo;
        #endregion

        #region Property
        public List<CHUONGTRAI> CHUONGTRAIs { get => _ChuongTrais; set { _ChuongTrais = value; OnPropertyChanged(); } }
        public string MaChuong { get => _MaChuong; set { _MaChuong = value; OnPropertyChanged(); } }
        public string MaLoaiChuong { get => _MaLoaiChuong; set { _MaLoaiChuong = value; OnPropertyChanged(); } }
        public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }
        public int SucChuaToiDa { get => _SucChuaToiDa; set { _SucChuaToiDa = value; OnPropertyChanged(); } }
        public int SoLuongHeo { get => _SoLuongHeo; set { _SoLuongHeo = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand ThemCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        #endregion

        public ThemChuongVM()
        {
            MaChuong = LayMa();
            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                foreach(var item in _ChuongTrais)
                {
                    DataProvider.Ins.DB.CHUONGTRAIs.Add(item);
                }    
                DataProvider.Ins.DB.SaveChanges();
                _ChuongTrais.Clear();
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();
            });
            ThemCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                var ChuongTrai = new CHUONGTRAI() { MaChuong = MaChuong, MaLoaiChuong = MaLoaiChuong, TinhTrang = TinhTrang, SuaChuaToiDa = SucChuaToiDa, SoLuongHeo = SoLuongHeo };
                _ChuongTrais.Add(ChuongTrai);
                p.Items.Refresh();
            });
        }
        string CreatMaChuong(int lan)
        {
            ObservableCollection<CHUONGTRAI> Chuongs = new ObservableCollection<CHUONGTRAI>(DataProvider.Ins.DB.CHUONGTRAIs);
            int soChuong;
            if (_ChuongTrais != null)
            { soChuong = Chuongs.Count + _ChuongTrais.Count + lan; }
            else
            {
                soChuong = Chuongs.Count + lan;
            }
            string maChuong;
            if (soChuong == 0)
            {
                maChuong = "CHUONG1" + DateTime.Now.ToString("_ddMM");
            }
            else
            {
                int STT = soChuong;
                STT++;
                string strSTT = STT.ToString();
                for (int i = strSTT.Length; i <= 5; i++)
                {
                    strSTT = "0" + strSTT;
                }

                maChuong = "CHUONG" + strSTT + DateTime.Now.ToString("_ddMM");
            }
            return maChuong;
        }
        string LayMa()
        {
            string MaCu = CreatMaChuong(0);
            int i = 0;
            var SL = new List<CHUONGTRAI>(DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.MaChuong == MaCu));
            while (SL.Count > 0)
            {
                i++;
                MaCu = CreatMaChuong(i);
                SL = new List<CHUONGTRAI>(DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.MaChuong == MaCu));
            }
            return MaCu;
        }
    }
}
