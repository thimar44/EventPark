using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPark.BO;
using EventPark.Models;

namespace EventPark.Controllers
{
    public class EvenementController : Controller
    {
        // GET: Evenement
        public ActionResult Index()
        {

            Adresse testAdress = new Adresse();
            Evenement testEvent = new Evenement(
                Guid.NewGuid(),
                "theme",
                new DateTime(),
                "horaire",
                120,
                testAdress,
                "description",
                99, 
                null);
            EvenementViewModel testMode = new EvenementViewModel(testEvent);
            List<EvenementViewModel> lst = new List<EvenementViewModel>();
            lst.Add(testMode);
            return View(lst);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
