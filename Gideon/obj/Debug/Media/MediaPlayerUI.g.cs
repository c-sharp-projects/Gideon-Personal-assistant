﻿#pragma checksum "..\..\..\Media\MediaPlayerUI.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A061B77188373653C08528DB4A1A6F3347F5787E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gideon.Media;
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


namespace Gideon.Media {
    
    
    /// <summary>
    /// MediaPlayerUI
    /// </summary>
    public partial class MediaPlayerUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement MyMediaElement;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Seeker;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PlayTime;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Previous;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlayOrPause;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar Volume;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AudioList;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VideoList;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Media\MediaPlayerUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PlayList;
        
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
            System.Uri resourceLocater = new System.Uri("/Gideon;component/media/mediaplayerui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Media\MediaPlayerUI.xaml"
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
            
            #line 9 "..\..\..\Media\MediaPlayerUI.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Grid_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MyMediaElement = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 3:
            this.Seeker = ((System.Windows.Controls.Slider)(target));
            
            #line 39 "..\..\..\Media\MediaPlayerUI.xaml"
            this.Seeker.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.Seek_Drag_Started));
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\Media\MediaPlayerUI.xaml"
            this.Seeker.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Seek_Drag_Completed));
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\Media\MediaPlayerUI.xaml"
            this.Seeker.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Seek_Value_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PlayTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Previous = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Media\MediaPlayerUI.xaml"
            this.Previous.Click += new System.Windows.RoutedEventHandler(this.ActionListener);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PlayOrPause = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Media\MediaPlayerUI.xaml"
            this.PlayOrPause.Click += new System.Windows.RoutedEventHandler(this.ActionListener);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Next = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Media\MediaPlayerUI.xaml"
            this.Next.Click += new System.Windows.RoutedEventHandler(this.ActionListener);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Volume = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            this.AudioList = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Media\MediaPlayerUI.xaml"
            this.AudioList.Click += new System.Windows.RoutedEventHandler(this.ActionListener);
            
            #line default
            #line hidden
            return;
            case 10:
            this.VideoList = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\Media\MediaPlayerUI.xaml"
            this.VideoList.Click += new System.Windows.RoutedEventHandler(this.ActionListener);
            
            #line default
            #line hidden
            return;
            case 11:
            this.PlayList = ((System.Windows.Controls.ListBox)(target));
            
            #line 96 "..\..\..\Media\MediaPlayerUI.xaml"
            this.PlayList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

