using QuanLyTraiHeo.Model;
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
    public class ChuongUC_VM: BaseViewModel
    {
        #region command
        public ICommand OpenLichChuongCommand { get; set; }
        public ICommand OpenListHeoCommand { get; set; }
        #endregion

        public ChuongUC_VM()
        {
            OpenLichChuongCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, p => { OpendLichChuong(p); });

            OpenListHeoCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, p => { OpendListHeo(p); });
        }

        void OpendLichChuong(FrameworkElement p)
        {
            if (p == null) return;

            wDSLichChuong wd = new wDSLichChuong();
            wd.ShowDialog();


        }

        void OpendListHeo(FrameworkElement p)
        {
            if (p == null) return;

            //CHUONGTRAI chuong = p.Tag as CHUONGTRAI;

            wDSHeo wd = new wDSHeo();
            wd.DataContext = new DSHeoVM();
            wd.ShowDialog();

        }
    }
}
