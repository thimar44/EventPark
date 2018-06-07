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
        private static List<EvenementViewModel> lst = new List<EvenementViewModel>();
        // GET: Evenement
        public ActionResult Index()
        {
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
                vm.id = Guid.NewGuid();

                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Image img = new Image();
                        img.id = Guid.NewGuid();

                        var fileI = Request.Files[i];
                        if (fileI != null && fileI.ContentLength > 0)
                        {
                            var fileName = img.id + Path.GetExtension(fileI.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), vm.id.ToString(), fileName);
                            if (!System.IO.File.Exists(path))
                            {
                                System.IO.Directory.CreateDirectory(Path.Combine(Server.MapPath("~/Images/"), vm.id.ToString()));

                                fileI.SaveAs(path);
                                img.Url = Path.Combine("Images/", vm.id.ToString(), fileName);
                                img.IsDefault = i.ToString() == Request.Form["imgDefault"];

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
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Image img = new Image();
                        img.id = Guid.NewGuid();

                        var fileI = Request.Files[i];
                        if (fileI != null && fileI.ContentLength > 0)
                        {
                            var fileName = img.id + Path.GetExtension(fileI.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), vm.id.ToString(), fileName);
                            if (!System.IO.File.Exists(path))
                            {
                                System.IO.Directory.CreateDirectory(Path.Combine(Server.MapPath("~/Images/"), vm.id.ToString()));

                                fileI.SaveAs(path);
                                img.Url = Path.Combine("Images/", vm.id.ToString(), fileName);
                                img.IsDefault = i.ToString() == Request.Form["imgDefault"];

                                vm.Images.Add(img);
                            }
                        }
                    }
                }
                
                vm.Update();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(Guid id)
        {
            EvenementViewModel vm = EvenementViewModel.Get(id);

            return View(vm);
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, EvenementViewModel vm)
        {
            try
            {
                vm.Delete();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
