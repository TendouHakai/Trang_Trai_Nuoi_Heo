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
    public class SoDoVM: BaseViewModel
    {

       

        #region Event command
        public ICommand LoadedWindowCommand { get; set; }
        #endregion
        public SoDoVM()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, p => { LoadSoDo(p); });
        }

        void LoadSoDo(Window p)
        {
            wSoDo wc = (p as wSoDo);
            if (wc == null) return;
            
            wc.wp_ListChuong.Children.Clear();

            List<CHUONGTRAI> listChuongTrai = new List<CHUONGTRAI>();
            listChuongTrai = DataProvider.Ins.DB.CHUONGTRAIs.ToList();

            foreach (var item in listChuongTrai)
            {
                IconChuongUC chuong = new IconChuongUC() { Tag = item };
                chuong.tb_SoLuongHeo.Text = DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.MaChuong == item.MaChuong).SingleOrDefault().HEOs.Count().ToString();
                chuong.tb_TenChuong.Text = item.MaChuong;
                chuong.DataContext = new ChuongUC_VM() { _SoLuongHeo = Int16.Parse(chuong.tb_SoLuongHeo.Text) };
                wc.wp_ListChuong.Children.Add(chuong);
            }


        }


    }
}
