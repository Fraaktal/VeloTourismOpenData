using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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

            string monumentListPath = @"SourceDatasets/commission-du-vieux-paris-adresses-instruites.json";
            MonumentParser monumentParser = new MonumentParser();
            var monumentList = monumentParser.Parse(monumentListPath);

            ModelComputer computer = new ModelComputer();
            var res = computer.ComputeNearVelibAndMonuments(pistes, listOfVelib, monumentList, 50);

            string path = $"C:\\Users\\trava\\OneDrive\\Bureau\\result.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            List<string> parsedData = new List<string>();

            foreach (var touristicTrack in res)
            {
                parsedData.Add(JsonConvert.SerializeObject(touristicTrack));
            }

            File.AppendAllLines(path, parsedData);
        }
    }
}
