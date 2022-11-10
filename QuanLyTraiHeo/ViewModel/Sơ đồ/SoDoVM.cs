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

            for (int i = 0; i < 10; i++)
            {
                wc.wp_ListChuong.Children.Add(new IconChuongUC() { DataContext = new ChuongUC_VM() });
            }

        }


    }
}
