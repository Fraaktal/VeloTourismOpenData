using System;
using VeloTourismOpenData.Control;
using VeloTourismOpenData.Parser;

namespace VeloTourismOpenData
{
    class Program
    {
        static void Main(string[] args)
        {
            string pistesPath = "C:\\Users\\trava\\OneDrive\\Bureau\\DATA\\reseau-cyclable.json";
            PisteParser parser = new PisteParser();
            var pistes = parser.Parse(pistesPath);

            string velibDatasetPath = new string(@"SourceDatasets/velib_a_paris_et_communes_limitrophes.json");
            var listOfVelib = VelibParser.ParseJson(velibDatasetPath);
        }
    }
}
