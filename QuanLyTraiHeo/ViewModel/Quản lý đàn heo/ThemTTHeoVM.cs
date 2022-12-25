using OfficeOpenXml;
using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.View.Windows;
using QuanLyTraiHeo.View.Windows.Quản_lý_giống_heo;
using QuanLyTraiHeo.View.Windows.Quản_lý_loại_heo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace QuanLyTraiHeo.ViewModel
{
    public class ThemTTHeoVM : BaseViewModel
    {
        private string matim;
        private string _MaHeo;
        private string _MaLoaiHeo;
        private string _MaGiongHeo;
        private string _GioiTinh;
        private int _TrongLuong;
        private DateTime? _NgaySinh;
        private string _MaChuong;
        private string _NguonGoc;
        private string _TinhTrang;
        private HEO _SelectedMe;
        private HEO _SelectedCha;
        private ObservableCollection<HEO> _ListHeoAdd;

        public ObservableCollection<HEO> ListHeoAdd { get => _ListHeoAdd; set { _ListHeoAdd = value; OnPropertyChanged(); } }
        public ObservableCollection<LOAIHEO> ListLoai { get; set; }
        public List<HEO> ListCha { get; }
        public List<HEO> ListMe { get; }
        public ObservableCollection<GIONGHEO> ListGiong { get; set; }
        public ObservableCollection<CHUONGTRAI> ListChuong { get; set; }



        public HEO HeoAdd { get; set; }
        public HEO SelectedMe { get => _SelectedMe; set { _SelectedMe = value; OnPropertyChanged(); } }
        public HEO SelectedCha { get => _SelectedCha; set { _SelectedCha = value; OnPropertyChanged(); } }
        public LOAIHEO SelectedLoai { get; set; }
        public GIONGHEO SelectedGiong { get; set; }
        public CHUONGTRAI SelectedChuong { get; set; }
        public string MaHeo { get => _MaHeo; set { _MaHeo=value;OnPropertyChanged(); } }
        public string MaLoaiHeo { get => _MaLoaiHeo; set { _MaLoaiHeo = value; OnPropertyChanged(); } }
        public string MaGiongHeo { get => _MaGiongHeo; set { _MaGiongHeo = value; OnPropertyChanged(); } }
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }
        public int TrongLuong { get => _TrongLuong; set { _TrongLuong = value; OnPropertyChanged(); } }
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }
        public string MaChuong { get => _MaChuong; set { _MaChuong = value; OnPropertyChanged(); } }
        public string MaHeoCha { get; set; }
        public string MaHeoMe { get; set; }
        public string NguonGoc { get => _NguonGoc; set { _NguonGoc = value; OnPropertyChanged(); } }
        public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }



        public ICommand AddCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExcelCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand TimKiemTheoMa_TenCommand { get; set; }


        public ThemTTHeoVM()
        {
            HEO X=new HEO();
            X.MaHeo = "Không Chọn";
            SelectedMe = SelectedCha = X;
            NguonGoc = "Sinh trong trang trại";
            TinhTrang = "Sức khoẻ tốt";
            ListHeoAdd = new ObservableCollection<HEO>();
            ListMe = new ObservableCollection<HEO>().ToList();
            ListCha = new ObservableCollection<HEO>().ToList();
            ListLoai = new ObservableCollection<LOAIHEO>(DataProvider.Ins.DB.LOAIHEOs);
            ListCha.Add(X); 
            var Cha = new ObservableCollection<HEO>(DataProvider.Ins.DB.HEOs.Where(x=>x.GioiTinh=="Đực")).ToList();
            
            foreach(HEO x in Cha){
                ListCha.Add(x);
            }
            ListMe.Add(X);
            var Me = new ObservableCollection<HEO>(DataProvider.Ins.DB.HEOs.Where(x => x.GioiTinh == "Cái")).ToList();
            foreach (HEO x in Me)
            {
                ListMe.Add(x);
            }
            ListGiong = new ObservableCollection<GIONGHEO>(DataProvider.Ins.DB.GIONGHEOs);
            ListChuong = new ObservableCollection<CHUONGTRAI>(DataProvider.Ins.DB.CHUONGTRAIs.Where(x=>x.SuaChuaToiDa>x.SoLuongHeo).ToList());
            MaHeo = LayMa();

            AddCommand = new RelayCommand<TextBox>((p) => {
                return true;
            }, p =>
            {
                if (GioiTinh == null)
                {
                    MessageBox.Show("Vui lòng chọn giới tính");
                    return;
                }
                if (NgaySinh == null || NgaySinh > DateTime.Today)
                {
                    MessageBox.Show("Vui lòng chọn lại ngày sinh");
                    return;
                }
                if (TrongLuong == null || TrongLuong <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đúng trọng lượng");
                    return;
                }
                if (SelectedLoai == null)
                {
                    MessageBox.Show("Vui lòng chọn loại heo");
                    return;
                }
                if (SelectedGiong == null)
                {
                    MessageBox.Show("Vui lòng chọn giống heo");
                    return;
                }
                if (SelectedChuong == null)
                {
                    MessageBox.Show("Vui lòng chọn mã chuồng");
                    return;
                }
                if (TinhTrang == null)
                {
                    MessageBox.Show("Vui lòng chọn tình trạng");
                    return;
                }
                if (NguonGoc == null)
                {
                    MessageBox.Show("Vui lòng chọn nguồn gốc");
                    return;
                }
                HeoAdd = new HEO();
                MaHeo = LayMa();
                HeoAdd.MaHeo = MaHeo;
                HeoAdd.GioiTinh = GioiTinh;
                HeoAdd.NgaySinh = NgaySinh;
                HeoAdd.TrongLuong = TrongLuong;
                HeoAdd.MaLoaiHeo = SelectedLoai.MaLoaiHeo;
                HeoAdd.MaGiongHeo = SelectedGiong.MaGiongHeo;
                HeoAdd.MaHeoMe = MaHeoMe;
                HeoAdd.MaHeoCha = MaHeoCha;
                HeoAdd.MaChuong = SelectedChuong.MaChuong;
                HeoAdd.NguonGoc = NguonGoc;
                HeoAdd.TinhTrang = TinhTrang;
                ListHeoAdd.Add(HeoAdd);
                GioiTinh = "";
                NgaySinh = null;
                TrongLuong = 0;
                MaLoaiHeo = "";
                MaGiongHeo = "";
                MaChuong = "";
                TinhTrang = "";
                NguonGoc = "";
                p.Text = LayMa();
            });

            HuyCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
                p.Close();
                ListHeoAdd = null;
            });

            DeleteCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
                ListHeoAdd.Remove(HeoAdd);
                MessageBox.Show(ListHeoAdd.Count().ToString());
            });

            ExcelCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {

                if(ListHeoAdd.Count>0)
                {
                    MessageBox.Show("Vui lòng chỉ import heo từ excel khi danh sách còn trống");
                    return;
                }
                string filePath = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Excel | *.xlsx";
                if (dialog.ShowDialog()==DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn không hợp lệ!");
                    return;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                try
                {

                    var package = new ExcelPackage(dialog.FileName);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    for(int i=worksheet.Dimension.Start.Row+1;i<=worksheet.Dimension.End.Row;i++)
                    {
                        int j = 1;
                        HEO x = new HEO();
                        x.MaHeo = LayMa();
                        x.GioiTinh = worksheet.Cells[i, j++].Value.ToString();
                        x.NgaySinh = DateTime.Parse( worksheet.Cells[i, j++].Value.ToString());

                        x.TrongLuong = int.Parse(worksheet.Cells[i, j++].Value.ToString());

                        var tenloai = worksheet.Cells[i, j++].Value.ToString();
                        x.LOAIHEO = new LOAIHEO();
                        foreach (LOAIHEO loai in ListLoai)
                        {
                            if(tenloai == loai.TenLoaiHeo)
                            {
                                x.LOAIHEO= loai;
                                 break;
                            }
                           
                        }
                        var tengiong = worksheet.Cells[i, j++].Value.ToString();
                        x.GIONGHEO = new GIONGHEO();
                        foreach (GIONGHEO giong in ListGiong)
                        {
                            if (tengiong == giong.TenGiongHeo)
                            {
                                x.GIONGHEO = giong;
                                break;
                            }
                        }
                        if(worksheet.Cells[i, j++].Value!=null)
                             x.MaHeoMe = worksheet.Cells[i, j].Value.ToString();
                        
                        if (worksheet.Cells[i, j++].Value != null)
                            x.MaHeoCha = worksheet.Cells[i, j].Value.ToString();
                        var mchuong = worksheet.Cells[i, j++].Value.ToString();
                        x.CHUONGTRAI = new CHUONGTRAI();
                        foreach (CHUONGTRAI chuong in ListChuong)
                        {
                            if (chuong.MaChuong.Contains(mchuong))
                            {
                                x.CHUONGTRAI = chuong;
                                break;
                            }
                        }
                        x.TinhTrang = worksheet.Cells[i, j++].Value.ToString();
                        x.NguonGoc = worksheet.Cells[i, j++].Value.ToString();

                        ListHeoAdd.Add(x);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi import từ excel");
                }
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
        string CreatMaHeo(int lan)
        {
            ObservableCollection<HEO> Heos = new ObservableCollection<HEO>(DataProvider.Ins.DB.HEOs);
            int soHeo;
            if (ListHeoAdd != null)
            { soHeo = Heos.Count + ListHeoAdd.Count + lan; }
            else
            {
                soHeo = Heos.Count + lan;
            }
            string maHeo;
            if (soHeo == 0)
            {
                maHeo = "HEO0000001" + DateTime.Now.ToString("_ddMM");
            }
            else
            {
                int STT = soHeo;
                STT++;
                string strSTT = STT.ToString();
                for (int i = strSTT.Length; i <= 6; i++)
                {
                    strSTT = "0" + strSTT;
                }

                maHeo = "HEO" + strSTT + DateTime.Now.ToString("_ddMM");
            }
            return maHeo;
        }
        string LayMa()
        {
            string MaCu = CreatMaHeo(0);
            int i = 0;
            var SL = new List<HEO>(DataProvider.Ins.DB.HEOs.Where(x => x.MaHeo == MaCu));
            while (SL.Count > 0)
            {
                i++;
                MaCu = CreatMaHeo(i);
                SL = new List<HEO>(DataProvider.Ins.DB.HEOs.Where(x => x.MaHeo == MaCu));
            }
            return MaCu;
        }
    }

}
