using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class SuaTTHeoVM: BaseViewModel
    {
        public ObservableCollection<HEO> ListHeo { get; set; }
        public ObservableCollection<LOAIHEO> ListLoai { get; set; }
        public ObservableCollection<GIONGHEO> ListGiong { get; set; }


        public HEO SelectedHeo { get; set; }
        public LOAIHEO SelectedLoai { get; set; }
        public GIONGHEO SelectedGiong { get; set; }


        public ICommand XacNhanCommand { get; set; }

        public SuaTTHeoVM()
        {
            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
                SelectedHeo = p.DataContext as HEO;
                DataProvider.Ins.DB.SaveChanges();
                p.Close();
            });
        }

    }
}
