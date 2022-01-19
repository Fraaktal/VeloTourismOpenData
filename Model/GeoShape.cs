using System;
using System.Collections.Generic;
using System.Text;

namespace VeloTourismOpenData.Model
{
    public class GeoShape
    {
        public GeoShape(double[][] coords)
        {
            Coordinates = coords;
        }

    public double[][] Coordinates { get; set; }
    }
}
