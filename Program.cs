using System;
using VeloTourismOpenData.Parser;

namespace VeloTourismOpenData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string velibDatasetPath = new string(@"SourceDatasets/velib_a_paris_et_communes_limitrophes.json");
            var listOfVelib = VelibParser.ParseJson(velibDatasetPath);
        }
    }
}
