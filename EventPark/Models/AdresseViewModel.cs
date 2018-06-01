using EventPark.BO;
using System;
using System.Collections.Generic;
using EventPark.Services;
namespace EventPark.Models
{
    public class AdresseViewModel : ViewModel<Adresse>
    {
        public AdresseViewModel()
        {
            this.Metier = new Adresse();
        }

        public AdresseViewModel(Adresse e)
        {
            this.Metier = e;
        }



       


        public String Rue
        {
            get
            {
                return this.Metier.rue;
            }
            set
            {
                this.Metier.rue = value;
            }
        }

        public String codePostal
        {
            get
            {
                return this.Metier.codePostal;
            }
            set
            {
                this.Metier.codePostal = value;
            }
        }


        

        public String Ville
        {
            get
            {
                return this.Metier.ville;
            }
            set
            {
                this.Metier.ville = value;
            }
        }

        public float CoordX
        {
            get
            {
                return this.Metier.coordX;
            }
            set
            {
                this.Metier.coordX = value;
            }
        }

        public float CoordY
        {
            get
            {
                return this.Metier.coordY;
            }
            set
            {
                this.Metier.coordY = value;
            }
        }

        public float Epsg
        {
            get
            {
                return this.Metier.epsg;
            }
            set
            {
                this.Metier.epsg = value;
            }
        }


        public void Save()
        {
            if (this.ID == Guid.Empty)
            {
                //insert
                ServiceAdresse.Insert(this.Metier);
            }
            else
            {
                //update
                ServiceAdresse.Update(this.Metier);
            }
        }

        public static List<AdresseViewModel> GetAll()
        {
            List<AdresseViewModel> retour = new List<AdresseViewModel>();


            List<Adresse> Adresses = ServiceAdresse.GetAll();
            foreach (Adresse e in Adresses)
            {
                retour.Add(new AdresseViewModel(e));
            }

            return retour;
        }



        /// <summary>
        /// retourne un Adresse ViewModel
        /// </summary>
        /// <param name="id">Identifiant nullable du Adresse</param>
        /// <returns>si id null, retourne un viewModel avec un Adresse initialisé; Si id a une valeur retourne le viewModel avec le Adresse en BDD
        /// </returns>
        public static AdresseViewModel Get(Guid? id)
        {
            AdresseViewModel retour = null;

            if (id.HasValue)
            {
                retour = new AdresseViewModel(ServiceAdresse.Get(id.Value));
            }
            else
            {
                Adresse e = new Adresse() { id = Guid.Empty };
                retour = new AdresseViewModel(e);
            }

            return retour;
        }
    }
}