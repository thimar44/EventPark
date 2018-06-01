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

        public Adresse(Guid id, string rue, string codePostal, string ville, float coordX, float coordY, float epsg)
        {
            this.id = id;
            this.rue = rue;
            this.codePostal = codePostal;
            this.ville = ville;
            this.coordX = coordX;
            this.coordY = coordY;
            this.epsg = epsg;
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
