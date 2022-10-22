using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuanLyTraiHeo.ViewModel
{
    public class QuanLyThongTinCaTheVM:BaseViewModel
    {
        public ICommand xemThongTin { get; }
        public QuanLyThongTinCaTheVM()
        {
            xemThongTin = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ThongTinHeo t = new ThongTinHeo();
                t.ShowDialog();
            });
        }

    }
}
