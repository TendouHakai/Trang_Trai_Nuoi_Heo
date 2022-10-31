using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraiHeo.ViewModel
{
    public class ThemTTHeoVM: BaseViewModel
    {
        public ObservableCollection<HEO> ListHeoAdd { get; set; }
        public ObservableCollection<LOAIHEO> ListLoai { get; set; }
        public ObservableCollection<GIONGHEO> ListGiong { get; set; }



        public HEO HeoAdd { get; set; }
        public HEO SelectedHeo { get; set; }
        public LOAIHEO SelectedLoai { get; set; }
        public GIONGHEO SelectedGiong { get; set; }

        public string MaHeo { get; set; }
        public string MaLoaiHeo { get; set; }
        public string MaGiongHeo { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MaChuong { get; set; }
        public string MaHeoCha { get; set; }
        public string MaHeoMe { get; set; }
        public string NguonGoc { get; set; }
        public string TinhTrang { get; set; }

        

        public ICommand AddCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }


        public ThemTTHeoVM()
        {
            ListHeoAdd = new ObservableCollection<HEO>();
            ListLoai = new ObservableCollection<LOAIHEO>(DataProvider.Ins.DB.LOAIHEOs);
            ListGiong = new ObservableCollection<GIONGHEO>(DataProvider.Ins.DB.GIONGHEOs);
            MaHeo = CreatMaHeo();

            AddCommand = new RelayCommand<TextBox>((p) => { return true; }, p =>
            {
                HeoAdd = new HEO();
                MaHeo = CreatMaHeo();
                HeoAdd.MaHeo = MaHeo;
                HeoAdd.GioiTinh = GioiTinh;
                HeoAdd.NgaySinh = NgaySinh;
                HeoAdd.MaLoaiHeo = MaLoaiHeo;
                HeoAdd.MaGiongHeo = MaGiongHeo;
                HeoAdd.MaHeoMe = MaHeoMe;
                HeoAdd.MaHeoCha = MaHeoCha;
                HeoAdd.NguonGoc = NguonGoc;
                HeoAdd.TinhTrang = TinhTrang;
                ListHeoAdd.Add(HeoAdd);
                p.Text = CreatMaHeo();
            });
            
            HuyCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
               p.Close();
               ListHeoAdd = null;
            });

            DeleteCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {               
               ListHeoAdd.Remove(HeoAdd);     
            });
            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
                foreach (var item in ListHeoAdd)
                {
                    DataProvider.Ins.DB.HEOs.Add(item);
                }    
                DataProvider.Ins.DB.SaveChanges();
                p.Close();
            });
            
        }
        string CreatMaHeo()
        {
            ObservableCollection<HEO> Heos = new ObservableCollection<HEO>(DataProvider.Ins.DB.HEOs);
            var soHeo=0;
            if (ListHeoAdd != null)
            { soHeo = Heos.Count + ListHeoAdd.Count; }
            else
            {
                soHeo = Heos.Count;
            }    
                string maHeo;                      
            if (soHeo == 0)
            {
                maHeo = "HEO000001"+DateTime.Now.ToString("_ddMM");
            }
            else
            {
                int STT = soHeo;
                STT++;
                string strSTT = STT.ToString();
                for (int i = strSTT.Length; i <= 5; i++)
                {
                    strSTT = "0" + strSTT;
                }

                maHeo = "HEO" + strSTT+DateTime.Now.ToString("_ddMM");
            }
            return maHeo;
        }
        
    }

}
