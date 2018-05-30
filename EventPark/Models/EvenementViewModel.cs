using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPark.Models
{
    public class EvenementViewModel:ViewModel<Evenement>
    {
        public EvenementViewModel()
        {
            this.Metier = new Evenement();
        }

        public EvenementViewModel(Evenement e)
        {
            this.Metier = e;
        }

        public String Theme
        {
            get
            {
                return this.Metier.theme;
            }
            set
            {
                this.Metier.theme = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.Metier.date;
            }
            set
            {
                this.Metier.date = value;
            }
        }

        public String Horaire
        {
            get
            {
                return this.Metier.horaire;
            }
            set
            {
                this.Metier.horaire = value;
            }
        }

        public int Duree
        {
            get
            {
                return this.Metier.duree;
            }
            set
            {
                this.Metier.duree = value;
            }
        }

        public Adresse Adresse
        {
            get
            {
                return this.Metier.adresse;
            }
            set
            {
                this.Metier.adresse = value;
            }
        }

        public String Descrition
        {
            get
            {
                return this.Metier.description;
            }
            set
            {
                this.Metier.description = value;
            }
        }

        public float Tarif
        {
            get
            {
                return this.Metier.tarif;
            }
            set
            {
                this.Metier.tarif = value;
            }
        }

        public List<String> Images
        {
            get
            {
                return this.Metier.images;
            }
            set
            {
                this.Metier.images = value;
            }
        }
    }
}