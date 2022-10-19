using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyTraiHeo.View.Windows.Quản_lý_đàn_heo;

namespace QuanLyTraiHeo.ViewModel
{ 
   public class PhieuBanHeoVM:BaseViewModel
    {
        public ICommand taoPhieuCommand { get; }
        public string hoten { get; set; }
        public PhieuBanHeoVM()
        {
            taoPhieuCommand = new RelayCommand<Window>((p) => {return true; }, (p)=>
            {
                PhieuNhapBanHeo PhieuNhapBanHeo = new PhieuNhapBanHeo();
                PhieuNhapBanHeo.ShowDialog();
            });
        }
    }
}
