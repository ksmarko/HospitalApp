﻿#pragma checksum "..\..\..\UI\AddDoctorWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4B770E8D9ED39D95C2E02D381D9E8A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalApp.UI;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace HospitalApp.UI {
    
    
    /// <summary>
    /// AddDoctorWindow
    /// </summary>
    public partial class HumanManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSurname;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblSpec;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSpec;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddDoc;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveDoc;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UI\AddDoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPat;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalApp;component/ui/adddoctorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\AddDoctorWindow.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lblSpec = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtSpec = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnAddDoc = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\UI\AddDoctorWindow.xaml"
            this.btnAddDoc.Click += new System.Windows.RoutedEventHandler(this.AddDoctor);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSaveDoc = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\UI\AddDoctorWindow.xaml"
            this.btnSaveDoc.Click += new System.Windows.RoutedEventHandler(this.EditDoctorData);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAddPat = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\UI\AddDoctorWindow.xaml"
            this.btnAddPat.Click += new System.Windows.RoutedEventHandler(this.AddPatient);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

