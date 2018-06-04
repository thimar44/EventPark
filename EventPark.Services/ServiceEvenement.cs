using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPark.BO;
using EventPark.DAL;

namespace EventPark.Services
{
    public static class ServiceEvenement
    {
        public static List<Evenement> GetAll()
        {
            List<Evenement> retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = context.Evenements.ToList();

            }
            return retour;
        }



        public static Evenement Get(Guid id)
        {
            Evenement retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = Get(id, context);

            }
            return retour;
        }


        private static Evenement Get(Guid id, EparkContext context)
        {
            return context.Evenements.Include("Images").Include("Adresse").FirstOrDefault(e => e.id == id);
        }

        public static void Insert(Evenement e)
        {
            using (EparkContext context = new EparkContext())
            {
                e.id = Guid.NewGuid();
                context.Evenements.Add(e);
                context.SaveChanges();
            }
        }

        public static void Update(Evenement e)
        {
            using (EparkContext context = new EparkContext())
            {
                EntityState s = context.Entry(e).State;
                Evenement eExistant = Get(e.id, context);
                eExistant.Theme = e.Theme;
                eExistant.Date = e.Date;
                eExistant.Horaire = e.Horaire;
                eExistant.Duree = e.Duree;
                eExistant.Adresse = e.Adresse;
                eExistant.Description = e.Description;
                eExistant.Tarif = e.Tarif;
                eExistant.Images = e.Images;
                eExistant.Titre = e.Titre;

                context.SaveChanges();
            }
        }
    }
}
