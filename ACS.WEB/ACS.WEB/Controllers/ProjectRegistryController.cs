using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    public class ProjectRegistryController : Controller
    {
        IProjectRegistryService ProjectRegistryService;
      
        public ProjectRegistryController(IProjectRegistryService serv)
        {
            ProjectRegistryService = serv;
        }

        // GET: ProjectRegistry
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectRegistry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectRegistry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectRegistry/Create
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

        // GET: ProjectRegistry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectRegistry/Edit/5
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

        // GET: ProjectRegistry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectRegistry/Delete/5
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
