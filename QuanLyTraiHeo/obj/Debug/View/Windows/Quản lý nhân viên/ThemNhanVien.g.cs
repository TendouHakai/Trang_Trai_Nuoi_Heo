﻿#pragma checksum "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "764798FE6E513DC8C06F79266A5D9FF0FE24E7257C0B2DE70A8CD709DF3F25BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên;
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


namespace QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên {
    
    
    /// <summary>
    /// ThemNhanVien
    /// </summary>
    public partial class ThemNhanVien : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên.ThemNhanVien ThemnewNhanVien;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btn_UpdateImage;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBChuVu;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grb_diachi;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grb_Ngayvaolam;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grb_Hesoluong;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Huybo;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyTraiHeo;component/view/windows/qu%e1%ba%a3n%20l%c3%bd%20nh%c3%a2n%20vi%c3%" +
                    "aan/themnhanvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
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
            this.ThemnewNhanVien = ((QuanLyTraiHeo.View.Windows.Quản_lý_nhân_viên.ThemNhanVien)(target));
            return;
            case 2:
            this.btn_UpdateImage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 113 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckIsNumber);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBChuVu = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.grb_diachi = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.grb_Ngayvaolam = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.grb_Hesoluong = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            
            #line 207 "..\..\..\..\..\View\Windows\Quản lý nhân viên\ThemNhanVien.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_Huybo = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

