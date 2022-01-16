using System;
using VeloTourismOpenData.Control;

namespace VeloTourismOpenData
{
    class Program
    {
        static void Main(string[] args)
        {
            string pistesPath = "C:\\Users\\trava\\OneDrive\\Bureau\\DATA\\reseau-cyclable.json";
            PisteParser parser = new PisteParser();
            var pistes = parser.Parse(pistesPath);
        }
    }
}
