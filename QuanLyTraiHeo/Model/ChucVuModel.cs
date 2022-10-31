using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyTraiHeo.Model
{
    public partial class ChucVuModel
    {

       public bool isSelected { get; set; }
       public string TenChucVu { get; set; }
       public ChucVuModel()
        {
            MessageBox.Show("Nếu thông báo này hiện, chương trình chắc chắn crash !!!");
        }
       public ChucVuModel(bool isSelected, string tenChucVu)
        {
            this.isSelected = isSelected;
            TenChucVu = tenChucVu;
        }
    }
}
