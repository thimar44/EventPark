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
                retour = context.Evenements.Include("Images").Include("Adresse").ToList();
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
                e.Adresse.id = Guid.NewGuid();
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

                eExistant.Images = e.Images;
                context.Entry(eExistant).CurrentValues.SetValues(e);               

                if (eExistant.Adresse.id == e.Adresse.id)
                {
                    context.Entry(eExistant.Adresse).CurrentValues.SetValues(e.Adresse);
                }
                else
                {
                    context.Adresses.Attach(e.Adresse);
                    eExistant.Adresse = e.Adresse;
                }

                context.SaveChanges();
            }
        }

        public static void Delete(Evenement e)
        {
            using (EparkContext context = new EparkContext())
            {
                EntityState s = context.Entry(e).State;
                context.Evenements.Attach(e);
                
                context.Evenements.Remove(e);
                context.Images.RemoveRange(e.Images);

                context.SaveChanges();
            }
        }
    }
}
