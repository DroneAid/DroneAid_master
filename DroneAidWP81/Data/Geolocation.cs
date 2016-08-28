using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace DroneAidWP81.Data
{
    public class Geolocation
    {
        public static async Task<Dictionary<string,double>> DeviceGeolocation()
        {
            try
            {
                Windows.Devices.Geolocation.Geolocator MyGeolocator = new Windows.Devices.Geolocation.Geolocator();
                MyGeolocator.DesiredAccuracy = PositionAccuracy.Default;

                Windows.Devices.Geolocation.Geoposition myGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10));
                Geocoordinate myGeocoordinate = myGeoPosition.Coordinate;

                Thread.Sleep(2000);
                Task.WaitAny();

                Dictionary<string,double> dictionary = new Dictionary<string,double>();
                dictionary.Add("Latitude",!String.IsNullOrEmpty(myGeocoordinate.Latitude.ToString()) ? myGeocoordinate.Latitude : 0.0);
                dictionary.Add("Longitude",!String.IsNullOrEmpty(myGeocoordinate.Longitude.ToString()) ? myGeocoordinate.Longitude : 0.0);
                return dictionary;

            }
            catch
            {
                return new Dictionary<string, double>();
            }
        }
    }
}
