using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventPark.BO;
using EventPark.Services;

namespace EventPark.Models
{
    public class ImageViewModel : ViewModel<Image>
    {
        public ImageViewModel()
        {
            this.Metier = new Image();
        }

        public ImageViewModel(Image i)
        {
            this.Metier = i;
        }

        public String Url
        {
            get
            {
                return this.Metier.Url;
            }
            set
            {
                this.Metier.Url = value;
            }
        }

        public Boolean Isdefault
        {
            get
            {
                return this.Metier.IsDefault;
            }
            set
            {
                this.Metier.IsDefault = value;
            }
        }

        public void Insert()
        {
            ServiceImage.Insert(this.Metier);
        }


        public void Update()
        {
            ServiceImage.Update(this.Metier);
        }


        public void Save()
        {



            if (this.id == Guid.Empty)
            {
                //insert
                ServiceImage.Insert(this.Metier);
            }
            else
            {
                //update
                ServiceImage.Update(this.Metier);
            }
        }

        public static List<ImageViewModel> GetAll()
        {
            List<ImageViewModel> retour = new List<ImageViewModel>();


            List<Image> Images = ServiceImage.GetAll();
            foreach (Image e in Images)
            {
                retour.Add(new ImageViewModel(e));
            }

            return retour;
        }



        /// <summary>
        /// retourne un Image ViewModel
        /// </summary>
        /// <param name="id">Identifiant nullable du Image</param>
        /// <returns>si id null, retourne un viewModel avec un Image initialisé; Si id a une valeur retourne le viewModel avec le Image en BDD
        /// </returns>
        public static ImageViewModel Get(Guid? id)
        {
            ImageViewModel retour = null;

            if (id.HasValue)
            {
                retour = new ImageViewModel(ServiceImage.Get(id.Value));
            }
            else
            {
                Image e = new Image() { id = Guid.Empty };
                retour = new ImageViewModel(e);
            }

            return retour;
        }

    }
}