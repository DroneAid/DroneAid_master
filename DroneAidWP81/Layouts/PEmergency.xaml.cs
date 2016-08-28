using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using DroneAidWP81.Data;
using DroneAidWP81.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;

namespace DroneAidWP81.Layouts
{
    public partial class PEmergency : PhoneApplicationPage
    {
        private Dictionary<string, double> geoposition;
        private DispatcherTimer timer;
        private EmergencyResponseModel emergencyResponse;
        private MapLayer mapLayer = new MapLayer();
        private int estimatedTime;
        
        public PEmergency()
        {
            InitializeComponent();

            //Load components
            this.Loaded += PEmergency_Loaded;
        }

        private async void PEmergency_Loaded(object sender, RoutedEventArgs e)
        {
            //Initialize timer
            timer = new DispatcherTimer();
            timer.Tick += DispatcherTimerEventHandler;
            timer.Interval = new TimeSpan(0, 0, 0, 1);

            //Collect current location
            geoposition = await Geolocation.DeviceGeolocation();

            //Call web service to send geoposition
            CallWebService();

        }
        

        private async void CallWebService()
        {
            //call Web service and returns data from drone
            emergencyResponse = await WebServices.EmergencyService(geoposition.ToList()[0].Value /*latitude*/, geoposition.ToList()[1].Value /*longitude*/);
          
            //Import to UI
            ProgressBarGrid.Visibility = Visibility.Collapsed;
            estimatedTime = int.Parse(emergencyResponse.sumMunites);
            
            //start timer
            timer.Start();
        }

        private void DispatcherTimerEventHandler(object sender, object e)
        {
            //stop timer
            if (estimatedTime == 0)
                return;

            TimeSpan t = TimeSpan.FromSeconds(double.Parse(estimatedTime.ToString()));

            EstimateTimeTxtbx.Text = string.Format("{0:D2}m:{1:D2}s",
                t.Minutes,
                t.Seconds);

            //Update Geolocation of drone on map
            UpdateSpot();

            //Calculate distances and reverse time
            estimatedTime = --estimatedTime;
            double absoluteValueLatitude = Math.Abs(double.Parse(emergencyResponse.droneInitialLatitude) - geoposition.ToList()[0].Value) / (double.Parse(emergencyResponse.sumMunites)*60);
            double absoluteValueLongitude = Math.Abs(double.Parse(emergencyResponse.droneInitialLongtitude) - geoposition.ToList()[1].Value) / double.Parse(emergencyResponse.sumMunites);
            geoposition["Latitude"] = (double.Parse(emergencyResponse.droneInitialLatitude) > geoposition.ToList()[0].Value) ? geoposition["Latitude"] + absoluteValueLatitude : geoposition["Latitude"] - absoluteValueLatitude;
            geoposition["Longitude"] = (double.Parse(emergencyResponse.droneInitialLongtitude) > geoposition.ToList()[1].Value) ? geoposition["Longitude"] + absoluteValueLongitude : geoposition["Longitude"] - absoluteValueLongitude;
        }

        private void UpdateSpot()
        {
            MapControl.Layers.Remove(mapLayer);
            mapLayer = new MapLayer();

            Grid MyGrid = new Grid();
            Image dangerareas = new Image();
            BitmapImage biareas = new BitmapImage();
            biareas.UriSource = new Uri("/Assets/dronePin.png", UriKind.Relative);
            dangerareas.Stretch = Stretch.Fill;
            dangerareas.Width = 60;
            dangerareas.Height = 60;
            dangerareas.Source = biareas;

            //Adding the Polygon to the Grid
            MyGrid.Children.Add(dangerareas);

            MapOverlay overlay = new MapOverlay();
            //overlay.GeoCoordinate = new GeoCoordinate(double.Parse(statusResponse[3]), double.Parse(statusResponse[3]));
            overlay.GeoCoordinate = new GeoCoordinate(geoposition["Latitude"], /*latitude*/ geoposition["Longitude"] /*longitude*/);
            overlay.PositionOrigin = new Point(0.5, 0.5);
            overlay.Content = MyGrid;
            mapLayer.Add(overlay);

            MapControl.Layers.Add(mapLayer);
            MapControl.ZoomLevel = 16;
            MapControl.Center = new GeoCoordinate(geoposition["Latitude"] /*latitude*/, geoposition["Longitude"] /*longitude*/);
                
        }

    }
}