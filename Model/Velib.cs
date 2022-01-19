using System.Device.Location;

namespace VeloTourismOpenData.Model
{
    public class Velib
    {
        public string Name { get; set; }
        public GeoCoordinate Localization { get; set; } 
        public string Address { get; set; }
    }
}
