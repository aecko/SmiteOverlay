﻿#pragma checksum "..\..\Items.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCC0302346BDAB6E8F803FEF3A5C63FB23843FC2904F751DFE5741D781ACC7EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SmiteOverlay;
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


namespace SmiteOverlay {
    
    
    /// <summary>
    /// Items
    /// </summary>
    public partial class Items : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UsernameValue_Label;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Avatar_Img;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToMain_Button;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item1_Image;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item2_Image;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item3_Image;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item4_Image;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item5_Image;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Item6_Image;
        
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
            System.Uri resourceLocater = new System.Uri("/SmiteOverlay;component/items.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Items.xaml"
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
            
            #line 9 "..\..\Items.xaml"
            ((SmiteOverlay.Items)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Items.xaml"
            ((SmiteOverlay.Items)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Items.xaml"
            ((SmiteOverlay.Items)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Items.xaml"
            ((SmiteOverlay.Items)(target)).LocationChanged += new System.EventHandler(this.Window_LocationChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UsernameValue_Label = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Avatar_Img = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.BackToMain_Button = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Items.xaml"
            this.BackToMain_Button.Click += new System.Windows.RoutedEventHandler(this.BackToMain_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Item1_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.Item2_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.Item3_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Item4_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.Item5_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Item6_Image = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

