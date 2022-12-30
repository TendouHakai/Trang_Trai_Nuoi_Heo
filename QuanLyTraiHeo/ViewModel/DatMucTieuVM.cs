using QuanLyTraiHeo.View.Windows.Thiết_lập_cây_mục_tiêu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class DatMucTieuVM:BaseViewModel
    {
        public THAMSOCMT thamso { get; set; }

        public ICommand HoanTatCommand { get; set; }
        public ICommand HuyCommand { get; set; }

        public DatMucTieuVM() { }
        public DatMucTieuVM(THAMSOCMT thamso)
        {
            this.thamso = thamso;

            #region command bộ lọc
            HoanTatCommand = new RelayCommand<Window>((p) => { return true; }, p => {
                p.Close();  
            });
            #endregion
        }
    }
}
