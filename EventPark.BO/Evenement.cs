using System;
using System.Collections.Generic;
using System.Text;

namespace EventPark.BO
{
    public class Evenement : IEntityIdentifiable
    {
        public Evenement()
        {

        }

        public Evenement(Guid pId, String pTheme, DateTime pDate, String pHoraire, int pDuree, Adresse pAdresse, String pDescription,float pTarif, List<String> pImages)
            :this()
        {
            this.id = pId;
            this.theme = pTheme;
            this.date = pDate;
            this.horaire = pHoraire;
            this.duree = pDuree;
            this.adresse = pAdresse;
            this.description = pDescription;
            this.tarif = pTarif;
            this.images = pImages;
        }

        public Guid id { get; set; }
        
        public String theme { get; set; }

        public DateTime date { get; set; }

        public String horaire { get; set; }

        public int duree { get; set; }

        public Adresse adresse { get; set; }

        public String  description { get; set; }

        public float tarif { get; set; }

        public List<String> images { get; set; }
    }
}
