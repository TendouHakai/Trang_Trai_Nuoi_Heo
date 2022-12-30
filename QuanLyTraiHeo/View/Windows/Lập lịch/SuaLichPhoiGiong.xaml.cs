using MaterialDesignThemes.Wpf;
using QuanLyTraiHeo.Model;
using QuanLyTraiHeo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyTraiHeo.View.Windows.Lập_lịch
{
    /// <summary>
    /// Interaction logic for SuaLichPhoiGiong.xaml
    /// </summary>
    public partial class SuaLichPhoiGiong : Window
    {
        LICHPHOIGIONG phoigiong;
        LapLichPhoiGiongVM lapLichPhoiGiongVM;
        public bool OK { get; set; }
        int temp { get; set; }
        static int check = 0;

        int? NhapSoCon;

        public SuaLichPhoiGiong(LICHPHOIGIONG LPG, LapLichPhoiGiongVM _lapLichPhoiGiongVM)
        {
            InitializeComponent();

            lapLichPhoiGiongVM = _lapLichPhoiGiongVM;
            OK = false;

            if (LPG != null)
            {
                phoigiong = LPG;
                Pigcode_textd.Text = LPG.MaHeoDuc;
                Pigcode_textn.Text = LPG.MaHeoCai;
                Datepicker_Ngayphoigiong.SelectedDate = LPG.NgayPhoiGiong;
                TrangThai.Text = LPG.Trangthai;
                Datepicker_ngayde.SelectedDate = LPG.NgayDuKienDe;
                Ngaycaisua.SelectedDate = LPG.NgayCaiSua;
                Ngaydethucte.SelectedDate = LPG.NgayDeThucTe;
                NgayPhoiGiongLai.SelectedDate = LPG.NgayPhoiGiongLaiDuKien;
                Socon.Text = LPG.SoCon.ToString();
                Soconchon.Text = LPG.SoConChon.ToString();
                Sochet.Text = LPG.SoConChet.ToString();

                NhapSoCon = LPG.SoConChon;

                SetUp(LPG.Trangthai);

                if (LPG.Trangthai == "Đã đẻ")
                {
                    TrangThai.IsEnabled = false;
                    Socon.IsEnabled = false;
                    Soconchon.IsEnabled = false;
                    Sochet.IsEnabled = false;
                }
            }
            else
            {
                Datepicker_Ngayphoigiong.SelectedDate = DateTime.Today; Datepicker_ngayde.IsEnabled = false;
                Ngaycaisua.IsEnabled = false;
                Ngaydethucte.IsEnabled = false;
                NgayPhoiGiongLai.IsEnabled = false;
                Socon.IsEnabled = false;
                Soconchon.IsEnabled = false;
                Sochet.IsEnabled = false;
            }


        }
        public LICHPHOIGIONG returnValue()
        {
            if (check == 1)
            {
                LICHPHOIGIONG phoigiong = new LICHPHOIGIONG();
                phoigiong.MaLichPhoi = temp;
                phoigiong.MaHeoDuc = Pigcode_textd.Text;
                phoigiong.MaHeoCai = Pigcode_textn.Text;
                phoigiong.NgayPhoiGiong = Datepicker_Ngayphoigiong.SelectedDate;
                phoigiong.Trangthai = TrangThai.Text;
                phoigiong.NgayDuKienDe = Datepicker_ngayde.SelectedDate;
                phoigiong.NgayCaiSua = Ngaycaisua.SelectedDate;
                phoigiong.NgayDeThucTe = Ngaydethucte.SelectedDate;
                phoigiong.NgayPhoiGiongLaiDuKien = NgayPhoiGiongLai.SelectedDate;
                if (Socon.Text == "")
                {
                    phoigiong.SoCon = null;
                }
                else
                {
                    phoigiong.SoCon = int.Parse(Socon.Text);
                }

                if (Soconchon.Text == "")
                {
                    phoigiong.SoConChon = null;
                }
                else
                {
                    phoigiong.SoConChon = Convert.ToInt16(Soconchon.Text);
                }

                if (Sochet.Text == "")
                {
                    phoigiong.SoConChet = null;
                }
                else
                {
                    phoigiong.SoConChet = Convert.ToInt16(Sochet.Text);
                }

                return phoigiong;
            }
            return null;
        }
        private void ListHeod_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListHeod();
        }

        private void ListHeon_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListHeoc();
        }


        void ShowListHeod()
        {
            DanhsachHeoDuc duc = new DanhsachHeoDuc();
            duc.ShowDialog();
            Pigcode_textd.Text = duc.TranferCode();
        }

        void ShowListHeoc()
        {
            DanhsachHeoCai cai = new DanhsachHeoCai();
            cai.ShowDialog();
            Pigcode_textn.Text = cai.TranferCode();
        }

        private void Confirm_button_Click(object sender, RoutedEventArgs e)
        {
            if (Datepicker_Ngayphoigiong.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Ngày giao phối phải từ hôm nay trở đi");
                return;
            }


            if (phoigiong == null)
            {
                //Tạo lịch mới 

                LICHPHOIGIONG lpg = DataProvider.Ins.DB.LICHPHOIGIONGs.Where(x => x.MaHeoCai == Pigcode_textn.Text && x.Trangthai == "Chưa phối giống").SingleOrDefault();
                if (lpg != null)
                {
                    MessageBox.Show(String.Format("Heo cái này đang có một lịch phối giống khác vào ngày {0} chưa được thực hiện", lpg.NgayPhoiGiong));
                    return;
                }

                THAMSO thamso = DataProvider.Ins.DB.THAMSOes.SingleOrDefault();
                if (BiCanHuyet(Pigcode_textd.Text, Pigcode_textn.Text, thamso.CanHuyet) == true)
                {

                    MessageBox.Show("Hệ thống phát hiện lịch phối sẽ sảy ra cận huyết, xin hãy kiểm tra lại");
                    return;
                }


                try
                {
                    LICHPHOIGIONG lich = new LICHPHOIGIONG();

                    lich.MaHeoDuc = Pigcode_textd.Text;
                    lich.MaHeoCai = Pigcode_textn.Text;
                    lich.NgayPhoiGiong = Datepicker_Ngayphoigiong.SelectedDate;
                    lich.Trangthai = TrangThai.Text;
                    lich.NgayDuKienDe = Datepicker_ngayde.SelectedDate;
                    lich.NgayCaiSua = Ngaycaisua.SelectedDate;
                    lich.NgayDeThucTe = Ngaydethucte.SelectedDate;
                    lich.NgayPhoiGiongLaiDuKien = NgayPhoiGiongLai.SelectedDate;
                    lich.SoCon = null;
                    lich.SoConChon = null;
                    lich.SoConChet = null;

                    DataProvider.Ins.DB.LICHPHOIGIONGs.Add(lich);

                    DataProvider.Ins.DB.SaveChanges();

                    OK = true;

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm");
                }
            }
            else
            {
                //Sửa lịch  

                phoigiong.MaHeoDuc = Pigcode_textd.Text;
                phoigiong.MaHeoCai = Pigcode_textn.Text;
                phoigiong.NgayPhoiGiong = Datepicker_Ngayphoigiong.SelectedDate;
                phoigiong.Trangthai = TrangThai.Text;
                phoigiong.NgayDuKienDe = Datepicker_ngayde.SelectedDate;
                phoigiong.NgayCaiSua = Ngaycaisua.SelectedDate;
                phoigiong.NgayDeThucTe = Ngaydethucte.SelectedDate;
                phoigiong.NgayPhoiGiongLaiDuKien = NgayPhoiGiongLai.SelectedDate;

                if(phoigiong.Trangthai != "Đã đẻ")
                {
                    phoigiong.SoCon = null;
                    phoigiong.SoConChon = null;
                    phoigiong.SoConChet = null;

                }
                else
                {
                    phoigiong.NgayCaiSua = Ngaycaisua.SelectedDate;

                    if(NhapSoCon != phoigiong.SoConChon || NhapSoCon == null)
                    {
                        //nếu lịch phối giống chưa thêm danh sách heo con thì sẽ thực hiện thêm
                        phoigiong.SoCon = int.Parse(Socon.Text);
                        phoigiong.SoConChet = Convert.ToInt16(Sochet.Text);

                        phoigiong.SoConChon = Convert.ToInt16(Soconchon.Text);

                        string maChuongHeoMe = DataProvider.Ins.DB.HEOs.Where(x => x.MaHeo == phoigiong.MaHeoCai).SingleOrDefault().MaChuong;
                        string maGiongHeoCha = DataProvider.Ins.DB.HEOs.Where(x => x.MaHeo == phoigiong.MaHeoDuc).SingleOrDefault().MaGiongHeo;

                        ThemTTHeo themheocon = new ThemTTHeo();
                        themheocon.DataContext = new ThemTTHeoVM(themheocon, phoigiong.MaHeoDuc, phoigiong.MaHeoCai, maChuongHeoMe, maGiongHeoCha, DateTime.Today, Convert.ToInt16(Soconchon.Text));
                        themheocon.ShowDialog();

                        if (phoigiong.NgayCaiSua != null)
                        {
                            LICHCHUONG lichCaiSua = new LICHCHUONG() { MaChuong = maChuongHeoMe, MaNguoiTao = Account.TaiKhoan.MaNhanVien, TenLich = "Cai sữa heo con", TrangThai = "Chưa làm", NgayLam = phoigiong.NgayCaiSua ?? DateTime.Now, Mota = "Ngày cai sữa heo con" };
                            DataProvider.Ins.DB.LICHCHUONGs.Add(lichCaiSua);
                        }

                    }

                }

                DataProvider.Ins.DB.SaveChanges();
                OK = true;
            }

            this.Close();
        }

        private void Huy_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chăc muốn hủy bỏ mọi thay đổi?", "Chú ý!", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Datepicker_Ngayphoigiong_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            THAMSO thamso = DataProvider.Ins.DB.THAMSOes.SingleOrDefault();
            Datepicker_ngayde.SelectedDate = Datepicker_Ngayphoigiong.SelectedDate.Value.AddDays(thamso.SoNgayMangThai);
            //Ngaycaisua.SelectedDate = Ngaycaisua.SelectedDate.Value.AddDays(thamso.);
            
        }

        private void TrangThai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((TrangThai.SelectedItem as ComboBoxItem).Content != null)
            {
                string trangThai = (TrangThai.SelectedItem as ComboBoxItem).Content.ToString();
                SetUp(trangThai);
            }
        }

        void SetUp(string trangThai)
        {
            Pigcode_textd.IsEnabled = true;
            Pigcode_textn.IsEnabled = true;
            Datepicker_Ngayphoigiong.IsEnabled = true;
            TrangThai.IsEnabled = true;
            Datepicker_ngayde.IsEnabled = false;
            Ngaycaisua.IsEnabled = false;
            Ngaydethucte.IsEnabled = false;
            NgayPhoiGiongLai.IsEnabled = true;
            Socon.IsEnabled = false;
            Soconchon.IsEnabled = false;
            Sochet.IsEnabled = false;

            if (trangThai == "Đã xảy thai" || trangThai == "Đã mang thai")
            {
                NgayPhoiGiongLai.IsEnabled = false;
            }
            else if (trangThai == "Đã đẻ")
            {
                Pigcode_textd.IsEnabled = true;
                Pigcode_textn.IsEnabled = true;
                Datepicker_Ngayphoigiong.IsEnabled = true;
                TrangThai.IsEnabled = true;
                Datepicker_ngayde.IsEnabled = false;
                Ngaycaisua.IsEnabled = true;
                Ngaydethucte.IsEnabled = false;
                NgayPhoiGiongLai.IsEnabled = false;
                Socon.IsEnabled = true;
                Soconchon.IsEnabled = true;
                Sochet.IsEnabled = true;

                Ngaydethucte.SelectedDate = DateTime.Today;

                THAMSO thamso = DataProvider.Ins.DB.THAMSOes.SingleOrDefault();
                Ngaycaisua.SelectedDate = DateTime.Today.AddDays(thamso.SoNgayCaiSua);
                NgayPhoiGiongLai.SelectedDate = Datepicker_Ngayphoigiong.SelectedDate.Value.AddDays(thamso.RePhoiGiongCai);
            }
        }

        bool BiCanHuyet(string _maHeoDuc, string _maHeoCai, int soLanKiemTra)
        {
            List<string> _ListMaHeoCha = new List<string>();

            List<string> _ListMaHeoCanHuyet_Duc = new List<string>();
            List<string> _ListMaHeoCanHuyet_Cai = new List<string>();

            for (int i = 0; i < soLanKiemTra; i++)
            {
                HEO heo = DataProvider.Ins.DB.HEOs.Where(x => x.MaHeo == _maHeoDuc).SingleOrDefault();

                if(heo != null)
                {
                    if (heo.MaHeoCha != null && heo.MaHeoMe != null)
                    {
                        _ListMaHeoCha.Add(heo.MaHeoCha);

                        _maHeoDuc = heo.MaHeoCha;
                    }
                }
                
            }

            foreach (var maHeoDuc in _ListMaHeoCha)
            {
                foreach (var heo in DataProvider.Ins.DB.HEOs)
                {
                    if (heo.MaHeoCha == _maHeoDuc && heo.MaLoaiHeo == "LH02112022000002") // nếu heo là heo nái và có heo cha thuộc phạm vị cận huyết thì thêm vào danh sách heo cái bị cận huyết 
                    {
                        _ListMaHeoCanHuyet_Cai.Add(heo.MaHeo);
                    }
                    else if (heo.MaHeoCha == _maHeoDuc && heo.MaLoaiHeo == "LH02112022000001") // nếu heo là heo đực và có heo cha thuộc phạm vị cận huyết thì thêm vào danh sách heo đực bị cận huyết
                    {
                        _ListMaHeoCanHuyet_Duc.Add(heo.MaHeo);
                    }
                }
            }

            foreach (var maheoduc in _ListMaHeoCanHuyet_Duc)
            {
                if (maheoduc == _maHeoDuc)
                {
                    return true;
                }
            }

            foreach (var maheocai in _ListMaHeoCanHuyet_Cai)
            {
                if (maheocai == _maHeoCai)
                {
                    return true;
                }
            }

            return false;
        }
    }
}



/*
using QuanLyTraiHeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyTraiHeo.View.Windows.Lập_lịch
{
    /// <summary>
    /// Interaction logic for SuaLichPhoiGiong.xaml
    /// </summary>
    public partial class SuaLichPhoiGiong : Window
    {
        string temp { get; set; }
        static int check = 0;

        public SuaLichPhoiGiong(LICHPHOIGIONG LPG)
        {
            InitializeComponent();
            temp = LPG.MaLichPhoi;
            Pigcode_textd.Text = LPG.MaHeoDuc;
            Pigcode_textn.Text = LPG.MaHeoCai;
            Datepicker_Ngayphoigiong.SelectedDate = LPG.NgayPhoiGiong;
            TrangThai.Text = LPG.Trangthai;
            Datepicker_ngayde.SelectedDate = LPG.NgayDuKienDe;
            Ngaycaisua.SelectedDate = LPG.NgayCaiSua;
            Ngaydethucte.SelectedDate = LPG.NgayDeThucTe;
            NgayPhoiGiongLai.SelectedDate = LPG.NgayPhoiGiongLaiDuKien;
            Socon.Text = LPG.SoCon.ToString();
            Soconchon.Text = LPG.SoConChon.ToString();
            Sochet.Text = LPG.SoConChet.ToString();
        }

        private void ListHeod_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListHeod();
        }

        private void ListHeon_button_Click(object sender, RoutedEventArgs e)
        {
            ShowListHeoc();
        }


        void ShowListHeod()
        {
            DanhsachHeoDuc duc = new DanhsachHeoDuc();
            duc.ShowDialog();
            Pigcode_textd.Text = duc.TranferCode();
        }

        void ShowListHeoc()
        {
            DanhsachHeoCai cai = new DanhsachHeoCai();
            cai.ShowDialog();
            Pigcode_textn.Text = cai.TranferCode();
        }

        private void Confirm_button_Click(object sender, RoutedEventArgs e)
        {
            check = 1;
            this.Close();
        }

        public LICHPHOIGIONG returnValue()
        {
            if (check == 1)
            {
                LICHPHOIGIONG phoigiong = new LICHPHOIGIONG();
                phoigiong.MaLichPhoi = temp;
                phoigiong.MaHeoDuc = Pigcode_textd.Text;
                phoigiong.MaHeoCai = Pigcode_textn.Text;
                phoigiong.NgayPhoiGiong = Datepicker_Ngayphoigiong.SelectedDate;
                phoigiong.Trangthai = TrangThai.Text;
                phoigiong.NgayDuKienDe = Datepicker_ngayde.SelectedDate;
                phoigiong.NgayCaiSua = Ngaycaisua.SelectedDate;
                phoigiong.NgayDeThucTe = Ngaydethucte.SelectedDate;
                phoigiong.NgayPhoiGiongLaiDuKien = NgayPhoiGiongLai.SelectedDate;
                if (Socon.Text == "")
                {
                    phoigiong.SoCon = null;
                }
                else
                {
                    phoigiong.SoCon = int.Parse(Socon.Text);
                }

                if (Soconchon.Text == "")
                {
                    phoigiong.SoConChon = null;
                }
                else
                {
                    phoigiong.SoConChon = Convert.ToInt16(Soconchon.Text);
                }

                if (Sochet.Text == "")
                {
                    phoigiong.SoConChet = null;
                }
                else
                {
                    phoigiong.SoConChet = Convert.ToInt16(Sochet.Text);
                }

                return phoigiong;
            }
            return null;
        }

        private void Huy_button_Click(object sender, RoutedEventArgs e)
        {
            check = 0;
            this.Close();
        }
    }
}
*/