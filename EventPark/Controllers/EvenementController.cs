using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPark.BO;
using EventPark.Models;
using EventPark.Services;

namespace EventPark.Controllers
{
    public class EvenementController : Controller
    {
        // GET: Evenement
        public ActionResult Index()
        {
            /*
            Adresse a1 = new Adresse(Guid.NewGuid(), "rue de la marte", "44140", "montbert", 0, 0, 0);
            Adresse a2 = new Adresse(Guid.NewGuid(), "rue de l'eni", "44500", "Saint herblain", 0, 0, 0);
            Adresse a3 = new Adresse(Guid.NewGuid(), "boulevard de la mort", "44000", "Nantes", 0, 0, 0);
            Adresse a4 = new Adresse(Guid.NewGuid(), "place napoléon", "85000", "La Roche sur Yon", 0, 0, 0);
            Adresse a5 = new Adresse(Guid.NewGuid(), "place napoléon", "85000", "La Roche sur Yon", 0, 0, 0);
            Adresse a6 = new Adresse(Guid.NewGuid(), "place napoléon", "85000", "La Roche sur Yon", 0, 0, 0);

            Evenement e1 = new Evenement(Guid.NewGuid(), "fête", new DateTime(2014, 6, 14, 6, 32, 0), "Fête de la saucisse", "15h",600,a1,"On mange, on boit, on rigole", 15, null );
            Evenement e2 = new Evenement(Guid.NewGuid(), "concert", new DateTime(2014, 6, 14, 6, 32, 0), "Metallica", "21h", 120, a2, "Du gros rock", 0, null);
            Evenement e3 = new Evenement(Guid.NewGuid(), "concert", new DateTime(2014, 6, 14, 6, 32, 0), "Sylvie Vartan", "19h", 180, a3, "Sylvie vartan en folie", 15, null);
            Evenement e4 = new Evenement(Guid.NewGuid(), "fête", new DateTime(2014, 6, 14, 6, 32, 0), "Fête des merguez", "15h", 600, a4, "Par ce que la merguez c'est meilleur !!", 15, null);
            Evenement e5 = new Evenement(Guid.NewGuid(), "danse", new DateTime(2014, 6, 14, 6, 32, 0), "Cours de danse classique", "15h", 120, a1, "ça va guincher !!", 15, null);
            Evenement e6 = new Evenement(Guid.NewGuid(), "concert", new DateTime(2014, 6, 14, 6, 32, 0), "Mickael Jackson", "22h", 120, a4, "Et oui il n'st pas mort, il vie en vendée depuis 5 ans", 15, null);
        

            EvenementViewModel eV1 = new EvenementViewModel(e1);
            EvenementViewModel eV2 = new EvenementViewModel(e2);
            EvenementViewModel eV3 = new EvenementViewModel(e3);
            EvenementViewModel eV4 = new EvenementViewModel(e4);
            EvenementViewModel eV5 = new EvenementViewModel(e5);
            EvenementViewModel eV6 = new EvenementViewModel(e6);
            

            eV1.Insert();
            eV2.Insert();
            eV3.Insert();
            eV4.Insert();
            eV5.Insert();
            eV6.Insert();
            */
            List<EvenementViewModel> lst = new List<EvenementViewModel>();

            lst = EvenementViewModel.GetAll();
            return View(lst);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            EvenementViewModel test = EvenementViewModel.Get(id);

            return View(test);
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(EvenementViewModel vm)
        {
            try
            {
                vm.id = Guid.NewGuid();
                vm.Insert();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
