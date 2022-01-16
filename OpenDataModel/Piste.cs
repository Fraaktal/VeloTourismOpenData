using System;
using System.Collections.Generic;
using System.Text;

namespace VeloTourismOpenData.OpenDataModel
{
    class Piste
    {
        public string typologie_simple { get; set; }
        public string bidirectionnel { get; set; }
        public string statut { get; set; }
        public string sens_velo { get; set; }
        public string voie { get; set; }
        public int arrdt { get; set; }
        public string bois { get; set; }
        public decimal length { get; set; }
        public decimal longueur_du_troncon_en_km { get; set; }
        public string position { get; set; }
        public string circulation { get; set; }
        public string piste { get; set; }
        public string couloir_bus { get; set; }
        public string type_continuite { get; set; }
        public string reseau { get; set; }
        public DateTime date_de_livraison { get; set; }
        public string geo_shape { get; set; } // (geo_shape)
        public string geo_point_2d { get; set; } // (geo_point_2d)
    }
}
