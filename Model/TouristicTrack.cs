using System.Collections.Generic;

namespace VeloTourismOpenData.Model
{
    public class TouristicTrack
    {
        public int Length_in_meters { get; set; }
        public GeoShape Geo_shape { get; set; }
        public List<Velib> NearVelibs { get; set; }
        //public List<Monument> NearMonuments { get; set; }
    }
}
