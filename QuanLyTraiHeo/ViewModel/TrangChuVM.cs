using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyTraiHeo.ViewModel
{
    public class TrangChuVM:BaseViewModel
    {
        private string tieude="";
        public string Tieude { get => tieude; set { tieude = value; OnPropertyChanged(); } }
        public TrangChuVM()
        {
            Tieude = "Nhật ký 2";
        }
    }
}
