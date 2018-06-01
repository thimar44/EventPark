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
    public static class ServiceImage
    {

        public static List<Image> GetAll()
        {
            List<Image> retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = context.Images.ToList();

            }
            return retour;
        }



        public static Image Get(Guid id)
        {
            Image retour = null;
            using (EparkContext context = new EparkContext())
            {
                retour = Get(id, context);

            }
            return retour;
        }


        private static Image Get(Guid id, EparkContext context)
        {
            return context.Images.FirstOrDefault(a => a.id == id);
        }

        public static void Insert(Image a)
        {
            using (EparkContext context = new EparkContext())
            {
                a.id = Guid.NewGuid();
                context.Images.Add(a);
                context.SaveChanges();
            }
        }

        public static void Update(Image a)
        {
            using (EparkContext context = new EparkContext())
            {
                EntityState s = context.Entry(a).State;
                Image aExistant = Get(a.id, context);
                aExistant.Url = a.Url;
                aExistant.IsDefault = a.IsDefault;
                context.SaveChanges();
            }
        }

    }
}
