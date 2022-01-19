using System;
using VeloTourismOpenData.Model;

namespace VeloTourismOpenData.OpenDataModel
{
    public class RecordMonument
    {
        public MonumentModel fields { get; set; }
    }
    
    public class MonumentModel
    {
        public double[] geo_point_2d { get; set; }
        public string designation { get; set; } // Name
        public string siecle_de_construction { get; set; } // ConstructionDate
        public string voeu { get; set; } // Description
    }
}
