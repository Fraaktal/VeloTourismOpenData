using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VeloTourismOpenData.Model;

namespace VeloTourismOpenData.Parser
{
    public class VelibParser
    {
        public static List<Velib> ParseJson(string path)
        {
            List<Velib> listOfVelib;

            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray velibArray = (JArray)JToken.ReadFrom(reader);
                listOfVelib = velibArray.Select(vel => new Velib
                {
                    Name = (string)vel["fields"]["name"],
                    Address = (string)vel["fields"]["address"],
                    Localization = new GeoPoint((double)vel["fields"]["latitude"], (double)vel["fields"]["longitude"])
                }).ToList();
            }

            return listOfVelib;
        } 
    }
}
