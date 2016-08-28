using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebService.Models
{
    [DataContract]
    public class DroneAidTransferInformation
    {
        public DroneAidTransferInformation(double patientPointLatitude, double droneInitialPointLatitude, double patientPointLongtitude, double droneInitialPointLongtitude) 
        {
            this.minutes = getMinutes(patientPointLatitude, droneInitialPointLatitude, patientPointLongtitude, droneInitialPointLongtitude);
            this.hours = getHours(patientPointLatitude, droneInitialPointLatitude, patientPointLongtitude, droneInitialPointLongtitude);
    ////            ((Math.Sqrt((patientPointLatitude - droneInitialPointLatitude) * (patientPointLatitude - droneInitialPointLatitude) +
    ////(patientPointLongtitude - droneInitialPointLongtitude) * (patientPointLongtitude - droneInitialPointLongtitude)) / 5) * 10000).ToString().Substring(0, 2);
                
                ////((Math.Sqrt((patientPointLatitude - droneInitialPointLatitude) * (patientPointLatitude - droneInitialPointLatitude) +
                ////(patientPointLongtitude - droneInitialPointLongtitude) * (patientPointLongtitude - droneInitialPointLongtitude)) / 5) * 10000).ToString().Substring(2, 2);

            this.distance = (Math.Sqrt((patientPointLatitude - droneInitialPointLatitude) * (patientPointLatitude - droneInitialPointLatitude) +
                (patientPointLongtitude - droneInitialPointLongtitude) * (patientPointLongtitude - droneInitialPointLongtitude)) * 100).ToString();
            this.sumMunites = (Convert.ToDouble(hours) * 60 + Convert.ToDouble(minutes)).ToString();

            this.droneInitialLatitude = droneInitialPointLatitude.ToString();
            this.droneInitialLongtitude = droneInitialPointLongtitude.ToString();
        }

        public DroneAidTransferInformation()
        {
        }

        [DataMember]
        public string hours { get; set; }

        [DataMember]
        public string minutes { get; set; }

        [DataMember]
        public string distance { get; set; }

        [DataMember]
        public string sumMunites { get; set; }

        [DataMember]
        public string droneInitialLongtitude { get; set; }

        [DataMember]
        public string droneInitialLatitude { get; set; }

        [DataMember]
        public string specialInfoMsg { get; set; }

        private string getMinutes(double patientPointLatitude, double droneInitialPointLatitude, double patientPointLongtitude, double droneInitialPointLongtitude) 
        {
           var time = ((Math.Sqrt((patientPointLatitude - droneInitialPointLatitude) * (patientPointLatitude - droneInitialPointLatitude) +
                (patientPointLongtitude - droneInitialPointLongtitude) * (patientPointLongtitude - droneInitialPointLongtitude)) / 5) * 10000).ToString();
           var minutes = time.Substring(time.IndexOf(".") - 2, 2);
           return minutes;
        }

        private string getHours(double patientPointLatitude, double droneInitialPointLatitude, double patientPointLongtitude, double droneInitialPointLongtitude) 
        {
            var time = ((Math.Sqrt((patientPointLatitude - droneInitialPointLatitude) * (patientPointLatitude - droneInitialPointLatitude) +
     (patientPointLongtitude - droneInitialPointLongtitude) * (patientPointLongtitude - droneInitialPointLongtitude)) / 5) * 10000).ToString();
            var hours = time.Substring(0, time.IndexOf(".") - 2);
            return hours;
        }
    }
}