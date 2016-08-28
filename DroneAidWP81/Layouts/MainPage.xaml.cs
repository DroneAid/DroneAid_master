using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DroneAidWP81.Data;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using DroneAidWP81.Models;
using Microsoft.Phone.Maps.Toolkit;
using System.Windows.Media;
using DroneAidWP81.MoreLayouts;
using System.IO.IsolatedStorage;
using Windows.Storage;
using System.Windows.Media.Imaging;

namespace DroneAidWP81
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string localFolderpath = ApplicationData.Current.LocalFolder.Path;
        private bool hasProfilePicture;
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            //Load more components
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Add spots
            List<PushpinModel> droneSpots = new List<PushpinModel>();
            droneSpots = Data.DummyData.Spots.DroneSpots();
            AddSpotsToMap(droneSpots);

            //Add Login Components
            LoginComponets();
        }

        private void LoginComponets()
        {
            //Try to collect user data from isolated storage
            try
            {
               Name.Text = (string)IsolatedStorageSettings.ApplicationSettings["FirstName"];
               LastName.Text = (string)IsolatedStorageSettings.ApplicationSettings["LastName"];
               //LogIn.Visibility = Visibility.Collapsed;
            }
            catch
            {
                //LogIn.Visibility = Visibility.Visible;
                return;
            }

            //Get profile picture
            using (var folder = IsolatedStorageFile.GetUserStoreForApplication())
            {
                hasProfilePicture = folder.FileExists("profilepicture.jpg");
            }
            if (String.IsNullOrEmpty(Name.Text))
            {
                if (hasProfilePicture)
                {
                    IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                    storage.DeleteFile("profilepicture.jpg");
                    return;
                }
            }
            if (hasProfilePicture)
            {
                string imagepath = localFolderpath + "\\profilepicture.jpg";
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(imagepath));
                ProfilePictureEllipse.Fill = myBrush;
            }
        }

        private void AddSpotsToMap(List<PushpinModel> droneSpots)
        {
            MapLayer mapLayer = new MapLayer();
            List<Pushpin> pushpins = new List<Pushpin>();
            PushPinDetails _tooltip;

            //Create new pushpins elements
            for (int i = 0; i < droneSpots.Count; i++)
            {
                _tooltip = new PushPinDetails();
                _tooltip.imgcont.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(droneSpots[i].icon);
                _tooltip.detailtitle.Text = string.Empty;

                _tooltip.Description = string.Empty;
                _tooltip.imgmarker.Source = _tooltip.imgcont.Source;
                _tooltip.imgmarker.Width = 60;
                _tooltip.imgmarker.Height = 60;
                //_tooltip.mapdetailstackpanel.Tap += btnMapNavig_Tap;
                //_tooltip.imgmarker.Tap += _tooltip_Tapimg;
                MapOverlay overlay = new MapOverlay();
                overlay.Content = _tooltip;
                overlay.GeoCoordinate = new GeoCoordinate(droneSpots[i].latitude, droneSpots[i].longitude);
                overlay.PositionOrigin = new Point(0.5, 0.5);
                mapLayer.Add(overlay);
            }
            myMap.Layers.Add(mapLayer);
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void btnTap_EmergencyButton(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Inform user for submit button
            MessageBoxResult result = MessageBox.Show("We are about to launch. Do you want to continue?", "Emergency Drone Call", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                //Navigate to emergency page
                NavigationService.Navigate(new Uri("/Layouts/PEmergency.xaml", UriKind.Relative));
            }
        }

        private void btnClick_LogIn(object sender, RoutedEventArgs e)
        {
            //Navigate to login page
            NavigationService.Navigate(new Uri("/Layouts/PLogin.xaml", UriKind.Relative));
        }
    }
}