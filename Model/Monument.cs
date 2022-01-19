namespace VeloTourismOpenData.Model
{
    public class Monument
    {
        public GeoPoint Localization { get; set; }
        public string Name { get; set; }
        public string ConstructionDate { get; set; }
        public string Description { get; set; }
    }
}
