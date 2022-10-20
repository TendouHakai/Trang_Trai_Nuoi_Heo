﻿using QuanLyTraiHeo.View.Windows.Quản_lý_chuồng_nuôi;
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

namespace QuanLyTraiHeo
{
    /// <summary>
    /// Interaction logic for QuanLyThongTinChuong.xaml
    /// </summary>
    public partial class QuanLyThongTinChuong : Window
    {
        public QuanLyThongTinChuong()
        {
            InitializeComponent();
        }

        private void btn_ThemClick(object sender, RoutedEventArgs e)
        {
            Themchuong themchuong = new Themchuong();
            themchuong.ShowDialog();
        }
        private void btn_SuaClick(object sender, RoutedEventArgs e)
        {
            SuaChuong suaChuong = new SuaChuong();
            suaChuong.ShowDialog();
        }
    }
}
