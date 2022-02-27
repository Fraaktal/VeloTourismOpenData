using System;
using System.Collections.Generic;
using System.Linq;
using VeloTourismOpenData.Model;

namespace VeloTourismOpenData.Control
{
    public class ModelComputer
    {
        //Compute les datasets pour créer nos données
        public List<TouristicTrack> ComputeNearVelibAndMonuments(List<TouristicTrack> tracks, List<Velib> velibs, List<Monument> monuments, int radius)
        {
            //On parcours chacune des pistes
            foreach (var track in tracks)
            {
                if (track?.Geo_shape != null)
                {
                    //Pour chacune des coords, on récupère les monuments et stations de vélibs dans un rayons de x mètres
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

                        foreach (var monument in monuments)
                        {
                            if (DistanceCalculator.Distance(coords[1], coords[0], monument.Localization.Coordinate[0],
                                monument.Localization.Coordinate[1]) < radius)
                            {
                                track.NearMonuments.Add(monument);
                            }
                        }
                    }
                }
            }

            return tracks;
        }

        //On calcule des circuits
        public List<TouristicCircuit> ComputeTouristicTracks(List<TouristicTrack> touristicTracks, int maxLength)
        {
            List<TouristicCircuit> result = new List<TouristicCircuit>();

            //On cherche 60 circuits
            result.AddRange(ComputeCircuit(touristicTracks, maxLength, 60));

            return result;
        }

        private List<TouristicCircuit> ComputeCircuit(List<TouristicTrack> touristicTracks, int maxLength, int count)
        {
            List<TouristicCircuit> res = new List<TouristicCircuit>();
            while (res.Count < count)
            {
                //On inclut une composante aléatoire.
                TouristicCircuit tmp = new TouristicCircuit();
                TouristicTrack startingPoint = null;
                Random r = new Random();

                while (startingPoint == null)
                {
                    int start = r.Next() % touristicTracks.Count;

                    if (touristicTracks[start].NearVelibs?.Count > 0)
                    {
                        startingPoint = touristicTracks[start];
                    }
                }
                
                bool canAddTrack = true;

                tmp.VelibStart = startingPoint.NearVelibs[r.Next() % startingPoint.NearVelibs.Count];
                tmp.PisteParcours.Add(startingPoint);
                TouristicTrack lastTrack = startingPoint;
                tmp.MonumentsToVisit.AddRange(startingPoint.NearMonuments);
                tmp.LengthInMeters = startingPoint.Length_in_meters;

                //Tant qu'on peut ajouter des pistes, on le fait et on ajoute des monuments. Les pistes doivent se suivre.
                while (canAddTrack)
                {
                    //On considère que deux pistes se suivent quand il y a moins de 10m entre deux pistes
                    var tracks = touristicTracks.Where(d => DistanceBetweenIsInferiorTo(d, lastTrack, 10)).ToList();
                    var monumentedTracks = tracks.Where(t => t.NearMonuments.Count > 0).ToList();
                    TouristicTrack nextTrack;

                    if (monumentedTracks.Count > 0)
                    {
                        nextTrack = monumentedTracks[r.Next() % monumentedTracks.Count];
                    }
                    else
                    {
                        nextTrack = tracks[r.Next() % tracks.Count];
                    }

                    if (nextTrack != null && tmp.LengthInMeters <= maxLength)
                    {
                        tmp.MonumentsToVisit.AddRange(startingPoint.NearMonuments);
                        tmp.LengthInMeters += nextTrack.Length_in_meters;
                        lastTrack = nextTrack;
                    }
                    else
                    {
                        tmp.VelibEnd = lastTrack.NearVelibs.FirstOrDefault();
                        canAddTrack = false;
                    }
                }

                //On ne valide un circuit que s'il y a au moins deux monuments à visiter
                if(tmp.MonumentsToVisit.Count> 1)
                {
                    string n1 = "";
                    string n2 = "";
                    if (tmp.MonumentsToVisit?.Count > 0)
                    {
                        n1 = string.IsNullOrEmpty(tmp.MonumentsToVisit.First().Name)
                            ? tmp.MonumentsToVisit.First().Adresse
                            : tmp.MonumentsToVisit.First().Name;

                        n2 = string.IsNullOrEmpty(tmp.MonumentsToVisit.Last().Name)
                            ? tmp.MonumentsToVisit.Last().Adresse
                            : tmp.MonumentsToVisit.Last().Name;
                    }
                    tmp.Name = n1 + " - " + n2;

                    res.Add(tmp);
                }
            }

            return res;
        }

        private bool DistanceBetweenIsInferiorTo(TouristicTrack t1, TouristicTrack t2, int value)
        {
            if (t1.Geo_shape != null && t2.Geo_shape != null)
            {
                foreach (var ct1 in t1.Geo_shape.Coordinates)
                {
                    foreach (var ct2 in t2.Geo_shape.Coordinates)
                    {
                        if (DistanceCalculator.Distance(ct1[1], ct1[0], ct2[1], ct2[0]) < value)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
