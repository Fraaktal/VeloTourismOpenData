namespace VeloTourismOpenData.Model
{
    public class Monument
    {
        public GeoPoint Localization { get; set; }
        public string Name { get; set; }
        public string ConstructionPeriode { get; set; }
        public int ConstructionDate { get; set; }
        public string Description { get; set; }
        public string Adresse { get; set; }
    }
}
