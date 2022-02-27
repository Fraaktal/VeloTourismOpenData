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

            //Parsing du dataset sur les vélibs
            string velibDatasetPath = new string(@"SourceDatasets/velib_a_paris_et_communes_limitrophes.json");
            var listOfVelib = VelibParser.ParseJson(velibDatasetPath);

            //Parsing du dataset sur les pistes cyclables
            string pistesPath = @"SourceDatasets/reseau-cyclable.json";
            PisteParser parser = new PisteParser();
            var pistes = parser.Parse(pistesPath);

            //Parsing du dataset sur les monuments de Paris
            string monumentListPath = @"SourceDatasets/commission-du-vieux-paris-adresses-instruites.json";
            MonumentParser monumentParser = new MonumentParser();
            var monumentList = monumentParser.Parse(monumentListPath);

            //On compute le nouveau modèle
            ModelComputer computer = new ModelComputer();
            var res = computer.ComputeNearVelibAndMonuments(pistes, listOfVelib, monumentList, 50);

            string path = $"C:\\Users\\trava\\OneDrive\\Bureau\\DATA\\result.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            List<string> parsedData = new List<string>();

            foreach (var touristicTrack in res)
            {
                parsedData.Add(JsonConvert.SerializeObject(touristicTrack));
            }

            //On enregistre le résultat
            File.AppendAllLines(path, parsedData);

            //On compute notre modèle pour créer des circuits (7km)
            var res2 = computer.ComputeTouristicTracks(res, 7000);

            string path2 = $"C:\\Users\\trava\\OneDrive\\Bureau\\DATA\\result2.json";

            if (File.Exists(path2))
            {
                File.Delete(path2);
            }

            List<string> parsedData2 = new List<string>();

            foreach (var touristicTrack in res2)
            {
                parsedData2.Add(JsonConvert.SerializeObject(touristicTrack));
            }

            //On enregistre le résultat
            File.AppendAllLines(path2, parsedData2);
        }
    }
}
