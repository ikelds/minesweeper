﻿#pragma checksum "..\..\CustomSettings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DE24073C96E13F8428AF2E6A48DD42DE22B19049E477A90926F64F3075A1CB28"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp22;


namespace WpfApp22 {
    
    
    /// <summary>
    /// CustomSettings
    /// </summary>
    public partial class CustomSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\CustomSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Auto_visible;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\CustomSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Auto_hide;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CustomSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Adjusted;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CustomSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxMines;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp22;component/customsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomSettings.xaml"
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
            
            #line 32 "..\..\CustomSettings.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.width_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 37 "..\..\CustomSettings.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.height_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Auto_visible = ((System.Windows.Controls.RadioButton)(target));
            
            #line 45 "..\..\CustomSettings.xaml"
            this.Auto_visible.Checked += new System.Windows.RoutedEventHandler(this.Radio_btn_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Auto_hide = ((System.Windows.Controls.RadioButton)(target));
            
            #line 49 "..\..\CustomSettings.xaml"
            this.Auto_hide.Checked += new System.Windows.RoutedEventHandler(this.Radio_btn_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Adjusted = ((System.Windows.Controls.RadioButton)(target));
            
            #line 53 "..\..\CustomSettings.xaml"
            this.Adjusted.Checked += new System.Windows.RoutedEventHandler(this.Radio_btn_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtBoxMines = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\CustomSettings.xaml"
            this.txtBoxMines.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.mines_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 65 "..\..\CustomSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Cust_OK);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 66 "..\..\CustomSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Cust_Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

