using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTraiHeo.Model;

namespace QuanLyTraiHeo.ViewModel
{
    public class PermissionUCVM
    {
        public bool check { get; set; }
        public PERMISION_DETAIL PermissionDetail { get; set; }

        public PermissionUCVM()
        {
            MessageBox.Show("Window này mà show là phải tìm bug ... !!!");
        }

        public PermissionUCVM(PERMISION_DETAIL pd = null)
        {
            PERMISION_DETAIL = pd;
        }

    }
}
