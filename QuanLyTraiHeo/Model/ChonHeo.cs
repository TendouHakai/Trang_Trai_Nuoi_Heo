using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTraiHeo.ViewModel;

namespace QuanLyTraiHeo.Model
{
    public class ChonHeo : BaseViewModel
    {
        public bool _IsChecked;
        public bool IsChecked { get => _IsChecked; set { _IsChecked = value; OnPropertyChanged(); } }
        public HEO heo { get; set; }
        public ChonHeo()
        {

        }
    }

}
