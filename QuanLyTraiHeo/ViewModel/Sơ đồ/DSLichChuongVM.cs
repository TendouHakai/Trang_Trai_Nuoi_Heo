using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraiHeo.ViewModel
{
    public class DSLichChuongVM
    {
        
        public string MaChuong { get; set; }
        public string LoaiChuong { get; set; }
        public int? SucChuaToiDa { get; set; }
        public int SoLuongHeo { get; set; }

        public DSLichChuongVM()
        {
            
        }
    }
}
