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

        public Evenement(Guid id, string theme, DateTime dateDebut, DateTime dateFin, string titre, Adresse adresse, string description, float tarif, List<Image> images)
        {
            this.id = id;
            this.Theme = theme;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Titre = titre;
            this.Adresse = adresse;
            this.Description = description;
            this.Tarif = tarif;
            this.Images = images;
        }

        public Guid id { get; set; }
        
        public String Theme { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public String Titre { get; set; }

        public Adresse Adresse { get; set; }

        public String  Description { get; set; }

        public float Tarif { get; set; }

        public List<Image> Images { get; set; }
    }
}
