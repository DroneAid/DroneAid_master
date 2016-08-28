using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DroneAidWP81.Layouts
{
    public partial class PLogin : PhoneApplicationPage
    {
        public PLogin()
        {
            InitializeComponent();
        }

        private void btnTap_FacebookLogin(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Navigate facebook page
            NavigationService.Navigate(new Uri("/Layouts/PFacebookLogin.xaml", UriKind.Relative));
        }
    }
}