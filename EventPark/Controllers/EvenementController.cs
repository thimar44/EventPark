using System;
using System.Collections.Generic;
using System.IO;
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
            List<EvenementViewModel> lst = new List<EvenementViewModel>();

            lst = EvenementViewModel.GetAll();
            return View(lst);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            EvenementViewModel vm = EvenementViewModel.Get(id);

            return View(vm);
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
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Image img = new Image();
                        var fileI = Request.Files[i];
                        if (fileI != null && fileI.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(fileI.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            if (!System.IO.File.Exists(path))
                            {
                                fileI.SaveAs(path);
                                img.id = Guid.NewGuid();
                                img.Url = fileName;

                                vm.Images.Add(img);
                            }
                        }
                    }
                }

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
            EvenementViewModel vm = EvenementViewModel.Get(id);
            return View(vm);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, EvenementViewModel vm)
        {
            try
            {
                vm.Update();

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
        public ActionResult Delete(int id, EvenementViewModel vm)
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
