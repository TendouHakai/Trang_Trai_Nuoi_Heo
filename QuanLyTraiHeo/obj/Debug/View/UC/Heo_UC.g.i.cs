﻿#pragma checksum "..\..\..\..\View\UC\Heo_UC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B14A6BC2ABA1340A8A3390929C6DBD0B28CB3F7ECB008E4C9B9D09B9DA18C8D"
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
using QuanLyTraiHeo.View.UC;
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


namespace QuanLyTraiHeo.View.UC {
    
    
    /// <summary>
    /// Heo_UC
    /// </summary>
    public partial class Heo_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_Heo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Heo;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_MaHeo;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_GioiTinh;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_TrongLuong;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_TenHanhKhach;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_LoaiHeo;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\View\UC\Heo_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TB_TinhTrang;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyTraiHeo;component/view/uc/heo_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\UC\Heo_UC.xaml"
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
            this.border_Heo = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.btn_Heo = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\View\UC\Heo_UC.xaml"
            this.btn_Heo.Click += new System.Windows.RoutedEventHandler(this.onButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TB_MaHeo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TB_GioiTinh = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TB_TrongLuong = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TB_TenHanhKhach = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.TB_LoaiHeo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TB_TinhTrang = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

