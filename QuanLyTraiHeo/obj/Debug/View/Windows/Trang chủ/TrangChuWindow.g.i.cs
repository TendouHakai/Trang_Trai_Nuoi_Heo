﻿#pragma checksum "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F72B9532BA3B46869FA269D4F04E5315192F1DBD03E485366D32F2DF2E43FC27"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyTraiHeo.View.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuanLyTraiHeo {
    
    
    /// <summary>
    /// TrangChuWindow
    /// </summary>
    public partial class TrangChuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLyTraiHeo.TrangChuWindow TrangChuW;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grb_TrangChu;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_DoanhThu;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon icon_DoanhThu;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tb_PhanTramDoanhThu;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tb_PhanTramDT;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyTraiHeo;component/view/windows/trang%20ch%e1%bb%a7/trangchuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TrangChuW = ((QuanLyTraiHeo.TrangChuWindow)(target));
            return;
            case 2:
            this.grb_TrangChu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tb_DoanhThu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.icon_DoanhThu = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 5:
            this.Tb_PhanTramDoanhThu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Tb_PhanTramDT = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 283 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
            ((LiveCharts.Wpf.PieChart)(target)).DataClick += new LiveCharts.Events.DataClickHandler(this.Chart_OnDataClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 304 "..\..\..\..\..\View\Windows\Trang chủ\TrangChuWindow.xaml"
            ((LiveCharts.Wpf.PieChart)(target)).DataClick += new LiveCharts.Events.DataClickHandler(this.Chart_OnDataClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

