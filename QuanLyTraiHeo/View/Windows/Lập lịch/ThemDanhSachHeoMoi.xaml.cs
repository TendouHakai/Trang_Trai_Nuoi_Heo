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
    /// Interaction logic for ThemDanhSachHeoMoi.xaml
    /// </summary>
    public partial class ThemDanhSachHeoMoi : Window
    {
        List<HEO> listHeoCon = new List<HEO>();

        public ThemDanhSachHeoMoi()
        {
            InitializeComponent();
        }

        public ThemDanhSachHeoMoi(int soLuongHeoCon, string maHeoCha, string maHeoMe, string maChuong, string maGiongHeo, DateTime ngaySinh)
        {
            InitializeComponent();


            for (int i = 0; i < soLuongHeoCon; i++)
            {
                HEO heocon = new HEO() { MaHeo = MaHeoCon(i+1), MaHeoCha = maHeoCha, MaHeoMe = maHeoMe, MaChuong = maChuong, MaLoaiHeo = "LH02112022000003", MaGiongHeo = maGiongHeo, NgaySinh = ngaySinh, NguonGoc = "Sinh trong trang trại" };
                listHeoCon.Add(heocon);
            }

            DG_List.ItemsSource = listHeoCon;
        }

        string MaHeoCon(int STT)
        {
            string maHeo = "";

            int soLuongHeo = DataProvider.Ins.DB.HEOs.Count() + 1;

            maHeo = "HEO" + soLuongHeo + "0"  + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + STT;

            return maHeo;
        }

        private void Confirm_button_Click(object sender, RoutedEventArgs e)
        {
            

            listHeoCon = DG_List.ItemsSource as List<HEO>;

            foreach (var item in listHeoCon)
            {
                DataProvider.Ins.DB.HEOs.Add(item);
            }

            DataProvider.Ins.DB.SaveChanges();

            this.Close();
        }
    }

    public class DataGridNumericColumn : DataGridTextColumn
    {
        protected override object PrepareCellForEdit(System.Windows.FrameworkElement editingElement, System.Windows.RoutedEventArgs editingEventArgs)
        {
            TextBox edit = editingElement as TextBox;
            edit.PreviewTextInput += OnPreviewTextInput;

            return base.PrepareCellForEdit(editingElement, editingEventArgs);
        }

        void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                // Show some kind of error message if you want

                // Set handled to true
                e.Handled = true;
            }
        }
    }
}
