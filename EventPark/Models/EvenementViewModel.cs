using EventPark.BO;
using System;
using System.Collections.Generic;
using EventPark.Services;
using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date de début")]
        public DateTime DateDebut
        {
            get
            {
                return this.Metier.DateDebut;
            }
            set
            {
                this.Metier.DateDebut = value;
            }
        }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de fin")]
        public DateTime DateFin
        {
            get
            {
                return this.Metier.DateFin;
            }
            set
            {
                this.Metier.DateFin = value;
            }
        }

        public String LibelleAdresse
        {
            get
            {
                return this.Metier.LibelleAdresse;
            }
            set
            {
                this.Metier.LibelleAdresse = value;
            }
        }

        public String Adresse
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

        public double lat
        {
            get
            {
                return this.Metier.lat;
            }
            set
            {
                this.Metier.lat = value;
            }
        }

        public double lng
        {
            get
            {
                return this.Metier.lng;
            }
            set
            {
                this.Metier.lng = value;
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

        public String Titre
        {
            get
            {
                return this.Metier.Titre;
            }
            set
            {
                this.Metier.Titre = value;
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

        [DataType(DataType.Upload)]
        public List<Image> Images
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

        public void Delete()
        {
            ServiceEvenement.Delete(this.Metier);
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