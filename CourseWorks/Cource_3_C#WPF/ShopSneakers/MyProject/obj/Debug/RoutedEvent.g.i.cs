﻿#pragma checksum "..\..\RoutedEvent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "174A8C4F65D5D7513B7FCDD72EE21AF746E84A0A1455F393927FE598C48E5B38"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MyProject;
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


namespace MyProject {
    
    
    /// <summary>
    /// RoutedEvents
    /// </summary>
    public partial class RoutedEvents : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DirectTextBlock;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BubblingTextBlock;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\RoutedEvent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TunellingTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/MyProject;component/routedevent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RoutedEvent.xaml"
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
            this.button1 = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            
            #line 47 "..\..\RoutedEvent.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Direct_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DirectTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 57 "..\..\RoutedEvent.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Bubbling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\RoutedEvent.xaml"
            this.button2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Bubbling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 80 "..\..\RoutedEvent.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Bubbling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BubblingTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 90 "..\..\RoutedEvent.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tunelling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\RoutedEvent.xaml"
            this.button3.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tunelling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 113 "..\..\RoutedEvent.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tunelling_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TunellingTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

