using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VeloTourismOpenData.Model;
using VeloTourismOpenData.OpenDataModel;

namespace VeloTourismOpenData.Parser
{
    public class PisteParser
    {
        public PisteParser()
        {

        }

        public List<TouristicTrack> Parse(string path)
        {
            var records = JsonConvert.DeserializeObject<List<Record>>(File.ReadAllText(path));

            if (records != null)
            {
                return Convert(records.Select(r => r.fields).ToList());
            }

            return null;
        }

        public List<TouristicTrack> Convert(List<Piste> pistes)
        {
            List<TouristicTrack> tracks = new List<TouristicTrack>();

            foreach (var piste in pistes)
            {
                TouristicTrack track = new TouristicTrack()
                {
                    Geo_shape = piste.geo_shape,
                    NearVelibs = new List<Velib>(),
                    Length_in_meters = (int)piste.length
                };

                tracks.Add(track);
            }

            return tracks;
        }
    }
}
