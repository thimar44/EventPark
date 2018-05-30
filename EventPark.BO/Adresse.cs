using System;
using System.Collections.Generic;
using System.Text;

namespace EventPark.BO
{
    public class Adresse : IEntityIdentifiable
    {
        public Adresse()
        {

        }

        public Adresse(Guid pId, String pRue, String pCodePostal, String pVille)
        {
            this.id = pId;
            this.rue = pRue;
            this.codePostal = pCodePostal;
            this.ville = pVille;
        }

        public Guid id { get; set; }

        public String rue { get; set; }

        public String codePostal { get; set; }

        public String  ville { get; set; }

        public float coordX { get; set; }

        public float coordY { get; set; }

        public float epsg { get; set; }
    }
}
