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
            this.Theme = theme;
            this.Date = date;
            this.Titre = titre;
            this.Horaire = horaire;
            this.Duree = duree;
            this.Adresse = adresse;
            this.Description = description;
            this.Tarif = tarif;
            this.Images = images;
        }

        public Guid id { get; set; }
        
        public String Theme { get; set; }

        public DateTime Date { get; set; }

        public String Titre { get; set; }

        public String Horaire { get; set; }

        public int Duree { get; set; }

        public Adresse Adresse { get; set; }

        public String  Description { get; set; }

        public float Tarif { get; set; }

        public List<String> Images { get; set; }
    }
}
