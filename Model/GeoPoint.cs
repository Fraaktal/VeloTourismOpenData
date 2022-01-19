namespace VeloTourismOpenData.Model
{
    public class GeoPoint
    {
        public GeoPoint(double x, double y)
        {
            Coordinate = new double[2];

            Coordinate[0] = x;
            Coordinate[1] = y;
        }

        public double[] Coordinate { get; set; }
    }
}
