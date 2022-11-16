using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.UC;
using QuanLyTraiHeo.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class DSHeoVM
    {
        wDSHeo wd;
        CHUONGTRAI chuong;

        #region Event command
        public ICommand LoadedWindowCommand { get; set; }
        #endregion
        public DSHeoVM(CHUONGTRAI _chuong)
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, p => { LoadListHeo(p); });
            chuong = _chuong;
        }

        void LoadListHeo(Window p)
        {
            wd = (p as wDSHeo);
            if (wd == null) return;

            wd.sp_ListHeo.Children.Clear();

            List<HEO> list = new List<HEO>();
            list = DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.MaChuong == chuong.MaChuong).SingleOrDefault().HEOs.ToList();

            foreach (var item in list)
            {
                Heo_UC heo = new Heo_UC();
                heo.TB_GioiTinh.Text = item.GioiTinh;
                heo.TB_MaHeo.Text = item.MaHeo;
                heo.TB_LoaiHeo.Text = item.MaLoaiHeo;
                heo.TB_TinhTrang.Text= item.TinhTrang;
                heo.TB_TrongLuong.Text = item.TrongLuong.ToString();
                heo.TB_NgaySinh.Text = item.NgaySinh.Value.Date.ToString("MM/dd/yyyy");
                heo.Click += Heo_Click;
                wd.sp_ListHeo.Children.Add(heo);
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    Heo_UC heo = new Heo_UC();
            //    heo.Click += Heo_Click;
            //    wd.sp_ListHeo.Children.Add(heo);
            //}
        }

        void Heo_Click(object sender, RoutedEventArgs e)
        {
            wd.sp_ListLich.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                LichUC lich = new LichUC();
                wd.sp_ListLich.Children.Add(lich);
            }
        }
    }
}
