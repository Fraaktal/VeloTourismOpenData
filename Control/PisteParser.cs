using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;
using VeloTourismOpenData.OpenDataModel;

namespace VeloTourismOpenData.Control
{
    public class PisteParser
    {
        public PisteParser()
        {

        }

        public List<Piste> Parse(string path)
        {
            var records = JsonConvert.DeserializeObject<List<Record>>(File.ReadAllText(path));

            return records.Select(r => r.fields).ToList();
        }
    }
}
