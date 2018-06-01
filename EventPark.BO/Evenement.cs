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

        public Evenement(Guid id, string theme, DateTime date, string titre, string horaire, int duree, Adresse adresse, string description, float tarif, List<string> images)
        {
            this.id = id;
            this.theme = theme;
            this.date = date;
            this.titre = titre;
            this.horaire = horaire;
            this.duree = duree;
            this.adresse = adresse;
            this.description = description;
            this.tarif = tarif;
            this.images = images;
        }

        public Guid id { get; set; }
        
        public String theme { get; set; }

        public DateTime date { get; set; }

        public String titre { get; set; }

        public String horaire { get; set; }

        public int duree { get; set; }

        public Adresse adresse { get; set; }

        public String  description { get; set; }

        public float tarif { get; set; }

        public List<String> images { get; set; }
    }
}
