using System;
using VeloTourismOpenData.Model;

namespace VeloTourismOpenData.OpenDataModel
{
    public class Record
    {
        public Piste fields { get; set; }
    }
    
    public class Piste
    {
        public decimal length { get; set; }
        public GeoShape geo_shape { get; set; } // (geo_shape)
    }
}
