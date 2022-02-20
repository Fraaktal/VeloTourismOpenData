using System;
using System.Collections.Generic;
using System.Text;

namespace VeloTourismOpenData.Model
{
    public class TouristicCircuit
    {
        public TouristicCircuit()
        {
            PisteParcours = new List<TouristicTrack>();
            MonumentsToVisit = new List<Monument>();
        }

        public string Name { get; set; }
        public int LengthInMeters { get; set; }
        public List<TouristicTrack> PisteParcours { get; set; }
        public Velib VelibStart { get; set; }
        public Velib VelibEnd { get; set; }
        public List<Monument> MonumentsToVisit { get; set; }
    }
}
