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
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
            using (EparkContext context = new EparkContext())
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            {
                retour = context.Evenements.ToList();

            }
            return retour;
        }



        public static Evenement Get(Guid id)
        {
            Evenement retour = null;
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            using (EparkContext context = new EparkContext())
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
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
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            using (EparkContext context = new EparkContext())
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
            {
                context.Evenements.Add(e);
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning disable CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
                context.SaveChanges();
#pragma warning restore CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            }
        }

        public static void Update(Evenement e)
        {
#pragma warning disable CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            using (EparkContext context = new EparkContext())
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning restore CS1674 // 'EparkContext' : le type utilisé dans une instruction using doit être implicitement convertible en 'System.IDisposable'
            {
#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning disable CS1061 // 'EparkContext' ne contient pas de définition pour 'Entry' et aucune méthode d'extension 'Entry' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
                EntityState s = context.Entry(e).State;
#pragma warning restore CS1061 // 'EparkContext' ne contient pas de définition pour 'Entry' et aucune méthode d'extension 'Entry' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
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

#pragma warning disable CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
#pragma warning disable CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
                context.SaveChanges();
#pragma warning restore CS1061 // 'EparkContext' ne contient pas de définition pour 'SaveChanges' et aucune méthode d'extension 'SaveChanges' acceptant un premier argument de type 'EparkContext' n'a été trouvée (une directive using ou une référence d'assembly est-elle manquante ?)
#pragma warning restore CS0012 // Le type 'IdentityDbContext<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
            }
        }
    }
}
