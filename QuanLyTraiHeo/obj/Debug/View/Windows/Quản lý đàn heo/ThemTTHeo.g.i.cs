﻿#pragma checksum "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F0F24AD19DC22648D4A961944D0EDCBF0A5C1E601B9EE9246B233B3CA743D687"
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
using QuanLyTraiHeo.View.Windows.Quản_lý_đàn_heo;
using QuanLyTraiHeo.ViewModel;
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


namespace QuanLyTraiHeo.View.Windows {
    
    
    /// <summary>
    /// ThemTTHeo
    /// </summary>
    public partial class ThemTTHeo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLyTraiHeo.View.Windows.ThemTTHeo ThemTTHeoW;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_MaHeo;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBLoaiHeo;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBGiongHeo;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyTraiHeo;component/view/windows/qu%e1%ba%a3n%20l%c3%bd%20%c4%91%c3%a0n%20he" +
                    "o/themttheo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
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
            this.ThemTTHeoW = ((QuanLyTraiHeo.View.Windows.ThemTTHeo)(target));
            return;
            case 2:
            this.txt_MaHeo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 40 "..\..\..\..\..\View\Windows\Quản lý đàn heo\ThemTTHeo.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBLoaiHeo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CBGiongHeo = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

