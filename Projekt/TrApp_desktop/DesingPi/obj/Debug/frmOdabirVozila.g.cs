﻿#pragma checksum "..\..\frmOdabirVozila.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53F8DCD90534FA43A7F06923593EE8E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DesingPi;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace DesingPi {
    
    
    /// <summary>
    /// SlobodnaVozila
    /// </summary>
    public partial class SlobodnaVozila : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DesingPi.SlobodnaVozila frmOdabirVozila;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid voziloDataGrid3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn id_voziloColumn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn nazivColumn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn nosivostColumn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn registracijaColumn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn vrsta_vozilaColumn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOdaberiVozilo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\frmOdabirVozila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
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
            System.Uri resourceLocater = new System.Uri("/DesingPi;component/frmodabirvozila.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmOdabirVozila.xaml"
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
            this.frmOdabirVozila = ((DesingPi.SlobodnaVozila)(target));
            
            #line 5 "..\..\frmOdabirVozila.xaml"
            this.frmOdabirVozila.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.voziloDataGrid3 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.id_voziloColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.nazivColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.nosivostColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.registracijaColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.vrsta_vozilaColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 8:
            this.btnOdaberiVozilo = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\frmOdabirVozila.xaml"
            this.btnOdaberiVozilo.Click += new System.Windows.RoutedEventHandler(this.btnOdaberiVozilo_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

