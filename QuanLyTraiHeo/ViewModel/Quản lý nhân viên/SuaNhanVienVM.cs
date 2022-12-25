using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using QuanLyTraiHeo.Model;
using MessageBox = System.Windows.MessageBox;

namespace QuanLyTraiHeo.ViewModel
{
    public class SuaNhanVienVM : BaseViewModel
    {
        public ICommand SuaCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand ImageChangedCommand { get; set; }
        public ObservableCollection<CHUCVU> listChucVu { get; set; }
        public CHUCVU chucvu { get; set; }
        public NHANVIEN TTNhanVien { get; set; }
       private System.Windows.Media.Imaging.BitmapImage image;
        public System.Windows.Media.Imaging.BitmapImage MyImage { get => image; set { image = value; OnPropertyChanged(); } }

        public SuaNhanVienVM()
        {
        }

        public SuaNhanVienVM(NHANVIEN nhanVien)
        {
            listChucVu = new ObservableCollection<CHUCVU>();
            LoadListChucVu();
            SuaCommand = new RelayCommand<Window>((p) => { return true; }, p => { Sua(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, p => { p.Close(); });
            ImageChangedCommand = new RelayCommand<object>((p) => { return true; }, p => { ChangeImage(); });

            TTNhanVien = nhanVien;
            chucvu = nhanVien.CHUCVU;
            MyImage = BytesToBitmapImage(nhanVien.BytesImage);

        }
        public static System.Windows.Media.Imaging.BitmapImage BytesToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new System.Windows.Media.Imaging.BitmapImage();
            using (var mem = new System.IO.MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        void ChangeImage()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Image (*.jpg)|*.jpg";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(dialog.FileName);
                TTNhanVien.BytesImage = (byte[])ImageToByteArray(bitmap);
                MyImage = BytesToBitmapImage(TTNhanVien.BytesImage);
            }
        }
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void LoadListChucVu()
        {
            var listchucvu = DataProvider.Ins.DB.CHUCVUs.ToList();
            foreach (var items in listchucvu)
                listChucVu.Add(items);

        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void Sua(Window p)
        {
            if (TTNhanVien.HoTen == String.Empty || TTNhanVien.HoTen == null)
            {
                MessageBox.Show("Vui lòng nhập họ tên ! ", "Thông báo!", MessageBoxButton.OK);
                return;
            }

            if (TTNhanVien.C_Username == String.Empty || TTNhanVien.C_Username == null)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập! ", "Thông báo!", MessageBoxButton.OK);
                return;
            }

            if (!IsValidEmail(TTNhanVien.email) && !string.IsNullOrEmpty(TTNhanVien.email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ! ", "Thông báo!", MessageBoxButton.OK);
                return;
            }

            if((TTNhanVien.SDT.Length <7 && TTNhanVien.SDT.Length >10  ) )
            {
                MessageBox.Show("Số điện thoại không hợp lệ! ", "Thông báo!", MessageBoxButton.OK);
                return;
            }

            if (TTNhanVien.HeSoLuong == null)
            {
                TTNhanVien.HeSoLuong = 0;
            }
            TTNhanVien.MaChucVu = chucvu.MaChucVu;

            TTNhanVien.HoTen.ToString().Replace(" ", "");
            TTNhanVien.C_Username.ToString().Replace(" ", "");
            TTNhanVien.TrangThai = "Đang làm việc";
            DataProvider.Ins.DB.SaveChanges();
            System.Windows.MessageBox.Show("Sửa thành công");

            p.Close();

        }

    }
}
