using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class QuanLyThongTinChuongVM : BaseViewModel
    {
        #region Attributes
        List<CHUONGTRAI> lstChuong;
        List<LOAICHUONG> lstLoaiChuong;
        int MaxSucChua = 0;
        int MaxHeo = 0;
        CHUONGTRAI _SelectedItem;
        CHUONGTRAI _ChuongTrai = new CHUONGTRAI();
        #endregion

        #region Property
        public List<CHUONGTRAI> LstChuong { get => lstChuong; set { lstChuong = value; OnPropertyChanged(); } }
        public CHUONGTRAI ChuongTrai { get => _ChuongTrai; set { _ChuongTrai = value; OnPropertyChanged(); } }
        public List<LOAICHUONG> LstLoaiChuong { get => lstLoaiChuong; set { lstLoaiChuong = value; OnPropertyChanged(); } }
        public CHUONGTRAI SelectedItem { get => _SelectedItem; 
            set { 
                _SelectedItem = value; OnPropertyChanged(); 
                if (SelectedItem != null) 
                {
                    ChuongTrai.MaChuong = SelectedItem.MaChuong;
                    ChuongTrai.MaLoaiChuong = SelectedItem.MaLoaiChuong;
                    ChuongTrai.TinhTrang = SelectedItem.TinhTrang;
                    ChuongTrai.SuaChuaToiDa = (int)SelectedItem.SuaChuaToiDa;
                    ChuongTrai.SoLuongHeo = (int)SelectedItem.SoLuongHeo;
                }
            }
        }
        public int MaxSC { get => MaxSucChua; set { MaxSucChua = value; OnPropertyChanged(); } }
        public int MaxSH { get => MaxHeo; set { MaxHeo = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        public QuanLyThongTinChuongVM()
        {
            AddCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Themchuong themChuong = new Themchuong();            
                themChuong.ShowDialog();
            });
            ShowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ThongTinChuong thongTinChuong = new ThongTinChuong();
                ThongTinChuongVM thongTinChuongVM = new ThongTinChuongVM(_ChuongTrai);
                thongTinChuong.DataContext = thongTinChuongVM;
                thongTinChuong.ShowDialog();           
            });
            EditCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                SuaChuong suaChuong = new SuaChuong();
                SuaChuongVM suaChuongVM = new SuaChuongVM(_ChuongTrai);
                suaChuong.DataContext = suaChuongVM;
                suaChuong.ShowDialog();
            });
            DeleteCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("xóa");
            });
            LoadListChuong();
            LoadListLoaiChuong();
            MaxC();
            MaxH();
        }

        void LoadListChuong()
        {
            lstChuong = new List<CHUONGTRAI>();
            var result = DataProvider.Ins.DB.CHUONGTRAIs;
            foreach (var item in result)
            {
                if (item != null)
                    lstChuong.Add(item);
            }
        }
        void MaxC()
        {
            lstChuong = new List<CHUONGTRAI>();
            var result = DataProvider.Ins.DB.CHUONGTRAIs;
            foreach (var item in result)
            {
                if (item != null)
                    lstChuong.Add(item);
            }
            foreach (var item in result)
            {
                if ((int)(item.SoLuongHeo) > MaxHeo)
                {
                    MaxHeo = (int)item.SoLuongHeo;
                }
            }
        }
        void MaxH()
        {
            lstChuong = new List<CHUONGTRAI>();
            var result = DataProvider.Ins.DB.CHUONGTRAIs;
            foreach (var item in result)
            {
                if (item != null)
                    lstChuong.Add(item);
            }
            foreach (var item in result)
            {
                if ((int)(item.SuaChuaToiDa) > MaxSucChua)
                {
                    MaxSucChua = (int)item.SuaChuaToiDa;
                }
            }
        }
        void LoadListLoaiChuong()
        {
            lstLoaiChuong = new List<LOAICHUONG>();
            var result2 = DataProvider.Ins.DB.LOAICHUONGs;
            foreach (var item in result2)
            {
                if (item != null)
                    lstLoaiChuong.Add(item);
            }    
        }
    }
}
