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
            return context.Evenements.FirstOrDefault(e => e.id == id);
        }

        public static void Insert(Evenement e)
        {
            using (EparkContext context = new EparkContext())
            {
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
                eExistant.theme = e.theme;
                eExistant.date = e.date;
                eExistant.horaire = e.horaire;
                eExistant.duree = e.duree;
                eExistant.adresse = e.adresse;
                eExistant.description = e.description;
                eExistant.tarif = e.tarif;
                eExistant.images = e.images;
                eExistant.titre = e.titre;

                context.SaveChanges();
            }
        }
    }
}
