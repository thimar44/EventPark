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
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            using (EparkContext context = new EparkContext())
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
            {
                context.Adresses.Add(a);
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning disable CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
                context.SaveChanges();
#pragma warning restore CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            }
        }

        public static void Update(Adresse a)
        {
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            using (EparkContext context = new EparkContext())
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
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
