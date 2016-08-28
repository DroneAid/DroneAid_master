using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DroneAidWP81.MoreLayouts
{
    public partial class PushPinDetails : UserControl
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public PushPinDetails()
        {
            InitializeComponent();
        }
    }
}
