using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Text;

namespace VeloTourismOpenData.Model
{
    public class Velib
    {
        public string Name { get; set; }
        public GeoCoordinate Localization { get; set; } 
        public string Address { get; set; }

    }
}
