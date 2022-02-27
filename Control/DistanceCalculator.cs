using System;

namespace VeloTourismOpenData.Control
{
    public static class DistanceCalculator
    {
        //Calcule la distance en m entre deux positions géographiques
        public static double Distance(double latA, double longA, double latB, double longB)
        {
            var d1 = latA * (Math.PI / 180.0);
            var num1 = longA * (Math.PI / 180.0);
            var d2 = latB * (Math.PI / 180.0);
            var num2 = longB * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var res = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            return res;
        }
    }
}
