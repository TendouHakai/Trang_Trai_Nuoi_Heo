using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyTraiHeo.ViewModel
{
    public class CapNhatTaiKhoanVM : BaseViewModel
    {
        private string hovaTenlot = "Trần Trung ";
        public string HovaTenlot { get => hovaTenlot; set { hovaTenlot = value; OnPropertyChanged(); } }
        public CapNhatTaiKhoanVM()
        {

        }
    }
}