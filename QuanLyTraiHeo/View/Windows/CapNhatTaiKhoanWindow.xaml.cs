using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace QuanLyTraiHeo.View.Windows
{
    /// <summary>
    /// Interaction logic for CapNhatTaiKhoanWindow.xaml
    /// </summary>
    public partial class CapNhatTaiKhoanWindow : Window
    {
        public CapNhatTaiKhoanWindow()
        {
            InitializeComponent();
        }

        private void btn_Huybo_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButton.YesNo);
            if (dlr == MessageBoxResult.Yes)
            {
                this.Close();
                return;
            }
            return;
        }
    }
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Bắt buộc")
                : ValidationResult.ValidResult;
        }
    }
}
