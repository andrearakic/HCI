﻿#pragma checksum "..\..\..\View\etiketaDodaj.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDDB000CDA43DD6B794F9D2DD68847598A6638C56539757BF0CA272634CFF47E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIprojekat;
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


namespace HCIprojekat {
    
    
    /// <summary>
    /// etiketaDodaj
    /// </summary>
    public partial class etiketaDodaj : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox oznakaEtikete;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox opisEtikete;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle pokazivac;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label greskaOznaka;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label greskaBoja;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\etiketaDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label greskaOpis;
        
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
            System.Uri resourceLocater = new System.Uri("/HCIprojekat;component/view/etiketadodaj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\etiketaDodaj.xaml"
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
            this.oznakaEtikete = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.opisEtikete = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 20 "..\..\..\View\etiketaDodaj.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_DodajEtiketu);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\..\View\etiketaDodaj.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pokazivac = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.greskaOznaka = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.greskaBoja = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.greskaOpis = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

