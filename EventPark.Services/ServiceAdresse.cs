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
    public static class ServiceAdresse
    {

        public static List<Adresse> GetAll()
        {
            List<Adresse> retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = context.Adresses.ToList();

            }
            return retour;
        }

        

        public static Adresse Get(Guid id)
        {
            Adresse retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = Get(id, context);

            }
            return retour;
        }

        
        private static Adresse Get(Guid id, EparkContext context)
        {
            return context.Adresses.FirstOrDefault(a => a.id == id);
        }

        public static void Insert(Adresse a)
        {
            using (EparkContext context = new EparkContext())
            {
                context.Adresses.Add(a);
                context.SaveChanges();
            }
        }

        public static void Update(Adresse a)
        {
            using (EparkContext context = new EparkContext())
            {
                EntityState s = context.Entry(a).State;
                Adresse aExistant = Get(a.id, context);
                aExistant.rue = a.rue;
                aExistant.codePostal = a.codePostal;
                aExistant.ville = a.ville;
                aExistant.coordX = a.coordX;
                aExistant.epsg = a.epsg;
                aExistant.coordY = a.coordY;

                context.SaveChanges();
            }
        }

    }
}
