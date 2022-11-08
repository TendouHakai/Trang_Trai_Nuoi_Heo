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

        #region Event command
        public ICommand LoadedWindowCommand { get; set; }
        #endregion
        public DSHeoVM()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, p => { LoadListHeo(p); });
        }

        void LoadListHeo(Window p)
        {
            wd = (p as wDSHeo);
            if (wd == null) return;

            wd.sp_ListHeo.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                Heo_UC heo = new Heo_UC();
                heo.Click += Heo_Click;
                wd.sp_ListHeo.Children.Add(heo);
            }
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
