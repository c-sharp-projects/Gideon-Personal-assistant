﻿#pragma checksum "..\..\..\Gallery\GalleryUI.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06B527ECC2E003AA45F9E2A2F4873506FD4FFED0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gideon.Gallery;
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


namespace Gideon.Gallery {
    
    
    /// <summary>
    /// GalleryUserInterface
    /// </summary>
    public partial class GalleryUserInterface : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Gallery\GalleryUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Thumbnails;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Gallery\GalleryUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Images;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Gallery\GalleryUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ImageList;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Gallery\GalleryUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ImgScreen;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Gallery\GalleryUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgsrc;
        
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
            System.Uri resourceLocater = new System.Uri("/Gideon;component/gallery/galleryui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Gallery\GalleryUI.xaml"
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
            
            #line 8 "..\..\..\Gallery\GalleryUI.xaml"
            ((Gideon.Gallery.GalleryUserInterface)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.KeyboardListener);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Thumbnails = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\..\Gallery\GalleryUI.xaml"
            this.Thumbnails.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxListener);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Images = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.ImageList = ((System.Windows.Controls.ListBox)(target));
            
            #line 47 "..\..\..\Gallery\GalleryUI.xaml"
            this.ImageList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxListener);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ImgScreen = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.imgsrc = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

