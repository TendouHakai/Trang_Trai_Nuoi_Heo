using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows.Thiết_lập_cây_mục_tiêu;
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
    public class SuaTTHeoVM : BaseViewModel
    {
        public ObservableCollection<LOAIHEO> ListLoai { get; set; }
        public ObservableCollection<GIONGHEO> ListGiong { get; set; }
        public ObservableCollection<CHUONGTRAI> ListChuong { get; set; }

        public string MaHeoMe { get; set; }
        public string MaHeoCha {get;set;}

        public HEO SelectedHeo { get; set; }
        public LOAIHEO SelectedLoai { get; set; }
        public GIONGHEO SelectedGiong { get; set; }
        public CHUONGTRAI SelectedChuong { get; set; }
        public CHUONGTRAI chuongBanDau { get; set; }

        public ICommand XacNhanCommand { get; set; }

        public SuaTTHeoVM()
        {
            return;
        }
        public SuaTTHeoVM(QuanLyThongTinCaTheVM vm)
        {
            HEO selectedHeo = vm.SelectedHeo;
            CHUONGTRAI cu = selectedHeo.CHUONGTRAI;
            SelectedHeo = selectedHeo;
            SelectedLoai = SelectedHeo.LOAIHEO;
            SelectedChuong = SelectedHeo.CHUONGTRAI;
            chuongBanDau = SelectedHeo.CHUONGTRAI;
            SelectedGiong = SelectedHeo.GIONGHEO;
            if(SelectedHeo.MaHeoCha!=null && SelectedHeo.MaHeoMe!=null)
            {
                MaHeoMe=SelectedHeo.MaHeoMe;
                MaHeoCha=SelectedHeo.MaHeoCha;
            }    
            ListLoai = new ObservableCollection<LOAIHEO>(DataProvider.Ins.DB.LOAIHEOs);
            ListGiong = new ObservableCollection<GIONGHEO>(DataProvider.Ins.DB.GIONGHEOs);
            ListChuong = new ObservableCollection<CHUONGTRAI>(DataProvider.Ins.DB.CHUONGTRAIs.Where(x => x.SuaChuaToiDa > x.SoLuongHeo).ToList());


            XacNhanCommand = new RelayCommand<Window>((p) =>
            {
                if (SelectedChuong == null || SelectedGiong == null || SelectedLoai == null)
                    return false;
                SelectedHeo.GIONGHEO = SelectedGiong;
                SelectedHeo.LOAIHEO = SelectedLoai;
                SelectedHeo.CHUONGTRAI = SelectedChuong;
                if (selectedHeo.GioiTinh == null || selectedHeo.TinhTrang == null || selectedHeo.NguonGoc == null || selectedHeo.NgaySinh == null || selectedHeo.TrongLuong == null)
                    return false;
                return true;
            }, p =>
            {
                
                if (!KiemTra())
                    return;
                if (SelectedHeo.CHUONGTRAI.SoLuongHeo < SelectedHeo.CHUONGTRAI.SuaChuaToiDa)
                {
                    SelectedHeo.CHUONGTRAI.SoLuongHeo += 1;
                    cu.SoLuongHeo -= 1;
                }
                else
                {
                    MessageBox.Show("Sức chứa của chuồng không đủ. Heo" + SelectedHeo.MaHeo + " chưa được sửa");
                    return;
                }
                DataProvider.Ins.DB.SaveChanges();
                vm.SelectedHeo = SelectedHeo; 
                p.Close();
            });
        }
        bool KiemTra()
        {
            string msg;
            if (SelectedHeo.GioiTinh == "Cái" && SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("đực"))
            {
                msg = "Chọn sai giới tính hoặc loại heo";
                MessageBox.Show(msg);
                return false;
            }
            if (SelectedHeo.GioiTinh == "Đực" && SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("nái"))
            {
                msg = "Chọn sai giới tính hoặc loại heo";
                MessageBox.Show(msg);
                return false;
            }

            if (SelectedHeo.MaHeoMe != null && SelectedHeo.MaHeoCha != null)
            {
                if (!(SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("con")) && (SelectedHeo.MaHeoMe != "Không chọn" || SelectedHeo.MaHeoCha != "Không chọn"))
                {
                    msg = "Chỉ chọn heo cha, heo mẹ cho heo thuộc loại heo con";
                    MessageBox.Show(msg);
                    return false;
                }
            }

            if (SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("nái"))
                if (!SelectedHeo.CHUONGTRAI.MaChuong.Contains("HN") && !SelectedHeo.CHUONGTRAI.MaChuong.Contains("HD"))
                {
                    msg = "Chuồng hiện tại không phù hợp với loại heo nái";
                    MessageBox.Show(msg);
                    return false;
                }
            if (SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("con") && SelectedHeo.CHUONGTRAI.MaChuong.Contains("DG"))
            {
                msg = "Heo con không thể ở chuồng đực giống";
                MessageBox.Show(msg);
                return false;
            }
            if (SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("đực") && (SelectedHeo.CHUONGTRAI.MaChuong.Contains("N") && SelectedHeo.CHUONGTRAI.MaChuong.Contains("HD")))
            {
                msg = "Heo đực không thể ở chuồng heo nái khác";
                MessageBox.Show(msg);
                return false;
            }
            if (SelectedHeo.LOAIHEO.TenLoaiHeo.Contains("thịt") && !SelectedHeo.CHUONGTRAI.MaChuong.Contains("T"))
            {
                msg = "Heo thịt chỉ có thể ở chuồng heo thịt";
                MessageBox.Show(msg);
                return false;
            }
            return true;
        }

    }
}