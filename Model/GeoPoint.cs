namespace VeloTourismOpenData.Model
{
    public class GeoPoint
    {
        public GeoPoint(double x, double y)
        {
            Coordinate = new decimal[2];

            Coordinate[0] = (decimal)x;
            Coordinate[1] = (decimal)y;
        }

        public decimal[] Coordinate { get; set; }
    }
}
