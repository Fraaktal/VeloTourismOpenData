using System;
using System.Collections.Generic;
using System.Text;

namespace VeloTourismOpenData.Model
{
    public class GeoShape
    {
        public GeoShape(decimal[][] coords)
        {
            Coordinates = coords;
        }

    public decimal[][] Coordinates { get; set; }
    }
}
