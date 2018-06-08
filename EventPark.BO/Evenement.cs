using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventPark.BO
{
    public class Evenement : IEntityIdentifiable
    {
        public Evenement()
        {

        }

        public Evenement(Guid id, string theme, DateTime dateDebut, DateTime dateFin, string titre, string libelleAdresse, string adresse, double lat, double lng, string description, float tarif, List<Image> images)
        {
            this.id = id;
            Theme = theme;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Titre = titre;
            LibelleAdresse = libelleAdresse;
            Adresse = adresse;
            this.lat = lat;
            this.lng = lng;
            Description = description;
            Tarif = tarif;
            Images = images;
        }

        public Guid id { get; set; }
        
        public String Theme { get; set; }

       
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public String Titre { get; set; }

        public String LibelleAdresse { get; set; }

        public String Adresse { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public String  Description { get; set; }

        public float Tarif { get; set; }

        public List<Image> Images { get; set; }
    }
}
