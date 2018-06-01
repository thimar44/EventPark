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
                return this.Metier.Theme;
            }
            set
            {
                this.Metier.Theme = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.Metier.Date;
            }
            set
            {
                this.Metier.Date = value;
            }
        }

        public String Horaire
        {
            get
            {
                return this.Metier.Horaire;
            }
            set
            {
                this.Metier.Horaire = value;
            }
        }

        public int Duree
        {
            get
            {
                return this.Metier.Duree;
            }
            set
            {
                this.Metier.Duree = value;
            }
        }

        public Adresse Adresse
        {
            get
            {
                return this.Metier.Adresse;
            }
            set
            {
                this.Metier.Adresse = value;
            }
        }

        public String Descrition
        {
            get
            {
                return this.Metier.Description;
            }
            set
            {
                this.Metier.Description = value;
            }
        }

        public float Tarif
        {
            get
            {
                return this.Metier.Tarif;
            }
            set
            {
                this.Metier.Tarif = value;
            }
        }

        public List<String> Images
        {
            get
            {
                return this.Metier.Images;
            }
            set
            {
                this.Metier.Images = value;
            }
        }


        public void Insert()
        {
            ServiceEvenement.Insert(this.Metier);
        }


        public void Update()
        {
            ServiceEvenement.Update(this.Metier);
        }


        public void Save()
        {



            if (this.id == Guid.Empty)
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
                Evenement e = new Evenement() { id = Guid.Empty, Titre = "Default" };
                retour = new EvenementViewModel(e);
            }

            return retour;
        }
    }
}