using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneAidWP81.Models
{
    public class EmergencyResponseModel
    {
        public string hours { get; set; }
        public string minutes { get; set; }
        public string distance { get; set; }
        public string sumMunites { get; set; }
        public string droneInitialLongtitude { get; set; }
        public string droneInitialLatitude { get; set; }
        public object specialInfoMsg { get; set; }
    }
}
