﻿#pragma checksum "C:\Users\giorgos\Documents\Visual Studio 2013\Projects\DroneAid\DroneAidWP81\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "562491968AF1847ED8EC2D70FFC5A005"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DroneAidWP81 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Panorama Panorama;
        
        internal System.Windows.Controls.Grid EmergencyGrid;
        
        internal Microsoft.Phone.Maps.Controls.Map myMap;
        
        internal System.Windows.Shapes.Ellipse prof_pic;
        
        internal System.Windows.Controls.TextBlock Name;
        
        internal System.Windows.Controls.TextBlock LastName;
        
        internal System.Windows.Controls.Button LogIn;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DroneAidWP81;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Panorama = ((Microsoft.Phone.Controls.Panorama)(this.FindName("Panorama")));
            this.EmergencyGrid = ((System.Windows.Controls.Grid)(this.FindName("EmergencyGrid")));
            this.myMap = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("myMap")));
            this.prof_pic = ((System.Windows.Shapes.Ellipse)(this.FindName("prof_pic")));
            this.Name = ((System.Windows.Controls.TextBlock)(this.FindName("Name")));
            this.LastName = ((System.Windows.Controls.TextBlock)(this.FindName("LastName")));
            this.LogIn = ((System.Windows.Controls.Button)(this.FindName("LogIn")));
        }
    }
}
