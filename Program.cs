using VeloTourismOpenData.Control;
using VeloTourismOpenData.Parser;

namespace VeloTourismOpenData
{
    class Program
    {
        static void Main(string[] args)
        {

            string velibDatasetPath = new string(@"SourceDatasets/velib_a_paris_et_communes_limitrophes.json");
            var listOfVelib = VelibParser.ParseJson(velibDatasetPath);

            string pistesPath = @"SourceDatasets/reseau-cyclable.json";
            PisteParser parser = new PisteParser();
            var pistes = parser.Parse(pistesPath);

            ModelComputer computer = new ModelComputer();
            computer.ComputeNearVelibAndMonuments(pistes, listOfVelib, 50);
        }
    }
}
