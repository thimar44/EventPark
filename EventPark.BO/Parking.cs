using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPark.BO
{
    class Parking
    {
        public String idAPI { get; set; }

        public String nom { get; set; }

        public Adresse adresse { get; set; }

        public String horairesOuverture { get; set; }

        public String status { get; set; }

        public int nbPlacesMax { get; set; }

        public int nbPlacesLibres { get; set; }

        public float tarif { get; set; }
    }
}
