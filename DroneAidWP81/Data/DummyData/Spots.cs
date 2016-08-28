using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroneAidWP81.Models;

namespace DroneAidWP81.Data.DummyData
{
    public class Spots
    {
        public static List<PushpinModel> DroneSpots()
        {
            List<PushpinModel> pushpinModel = new List<PushpinModel>();
            pushpinModel.Add(new PushpinModel() { latitude = 37.4097449, longitude = -122.0618475, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.409029, longitude = -122.0599807, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.4120458, longitude = -122.0566118, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.4132729, longitude = -122.065388, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.4161021, longitude = -122.0566977, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.4153863, longitude = -122.0548056, icon = "/Assets/dronePin.png"});
            pushpinModel.Add(new PushpinModel() { latitude = 37.4043077, longitude = -122.0642899, icon = "/Assets/dronePin.png"});

            return pushpinModel;
        }
    }
}
