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
            this.Rue = rue;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.Epsg = epsg;
        }

        public Guid id { get; set; }

        public String Rue { get; set; }

        public String CodePostal { get; set; }

        public String  Ville { get; set; }

        public float CoordX { get; set; }

        public float CoordY { get; set; }

        public float Epsg { get; set; }
    }
}
