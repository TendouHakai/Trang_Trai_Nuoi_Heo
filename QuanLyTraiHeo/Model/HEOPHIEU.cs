using QuanLyTraiHeo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraiHeo.Model
{
    public class HEOPHIEU : BaseViewModel
    {
        private bool _IsChecked;
        private int _DonGia;
        public bool IsChecked { get => _IsChecked; set { _IsChecked = value; OnPropertyChanged(); } }
        public HEO heo { get; set; }

        public int DonGia { get => _DonGia; set { _DonGia = value; OnPropertyChanged(); } }
        public HEOPHIEU()
        {
            _IsChecked = false;
            _DonGia = 0;
            heo = new HEO();
        }
    }
}
