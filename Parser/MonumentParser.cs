using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VeloTourismOpenData.Model;
using VeloTourismOpenData.OpenDataModel;

namespace VeloTourismOpenData.Parser
{
    public class MonumentParser
    {
        public List<Monument> Parse(string path)
        {
            var records = JsonConvert.DeserializeObject<List<RecordMonument>>(File.ReadAllText(path));

            if (records != null)
            {
                return Convert(records.Select(r => r.fields).ToList());
            }

            return null;
        }

        private List<Monument> Convert(List<MonumentModel> monumentModelList)
        {
            List<Monument> monumentList = new List<Monument>();

            foreach (var monumentModel in monumentModelList)
            {
                Monument track = new Monument()
                {
                    Localization = new GeoPoint(monumentModel.geo_point_2d[0], monumentModel.geo_point_2d[1]),
                    Name = monumentModel.designation,
                    ConstructionDate = monumentModel.siecle_de_construction,
                    Description = monumentModel.voeu
                };

                monumentList.Add(track);
            }

            return monumentList;
        }
    }
}
