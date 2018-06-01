using EventPark.BO;
using System;
using System.Collections.Generic;
using EventPark.Services;
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



        public void Save()
        {
            if (this.ID == Guid.Empty)
            {
                //insert
                ServiceEvenement.Insert(this.Metier);
            }
            else
            {
                //update
                ServiceEvenement.Update(this.Metier);
            }
        }

        public static List<EvenementViewModel> GetAll()
        {
            List<EvenementViewModel> retour = new List<EvenementViewModel>();


            List<Evenement> Evenements = ServiceEvenement.GetAll();
            foreach (Evenement e in Evenements)
            {
                retour.Add(new EvenementViewModel(e));
            }

            return retour;
        }



        /// <summary>
        /// retourne un Evenement ViewModel
        /// </summary>
        /// <param name="id">Identifiant nullable du Evenement</param>
        /// <returns>si id null, retourne un viewModel avec un Evenement initialisé; Si id a une valeur retourne le viewModel avec le Evenement en BDD
        /// </returns>
        public static EvenementViewModel Get(Guid? id)
        {
            EvenementViewModel retour = null;

            if (id.HasValue)
            {
                retour = new EvenementViewModel(ServiceEvenement.Get(id.Value));
            }
            else
            {
                Evenement e = new Evenement() { id = Guid.Empty, titre = "Default" };
                retour = new EvenementViewModel(e);
            }

            return retour;
        }
    }
}