using System;
using System.Collections.Generic;
using System.Text;
using VeloTourismOpenData.Model;

namespace VeloTourismOpenData.Control
{
    public class ModelComputer
    {
        public List<TouristicTrack> ComputeNearVelibAndMonuments(List<TouristicTrack> tracks, List<Velib> velibs, int radius)
        {
            foreach (var track in tracks)
            {
                if (track?.Geo_shape != null)
                {
                    foreach (var coords in track.Geo_shape.Coordinates)
                    {
                        foreach (var velib in velibs)
                        {
                            if (DistanceCalculator.Distance(coords[1], coords[0], velib.Localization.Coordinate[0],
                                velib.Localization.Coordinate[1]) < radius)
                            {
                                track.NearVelibs.Add(velib);
                            }
                        }

                        //foreach (var monument in monuments)
                        //{
                        //    if (DistanceCalculator.Distance(coords[0], coords[1], monument.Localization.Coordinate[0],
                        //        monument.Localization.Coordinate[1]) < radius)
                        //    {
                        //        track.NearMonuments.Add(monument);
                        //    }
                        //}
                    }
                }
            }

            return tracks;
        }
    }
}
