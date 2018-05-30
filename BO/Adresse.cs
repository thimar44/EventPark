using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Adresse
    {
        public Adresse()
        {

        }

        public Adresse(String pRue, String pCodePostal, String pVille)
        {
            this.rue = pRue;
            this.codePostal = pCodePostal;
            this.ville = pVille;
        }

        public String rue { get; set; }

        public String codePostal { get; set; }

        public String  ville { get; set; }
    }
}
