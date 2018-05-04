using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Areas.Admin.Controllers.ASPIdentityUser
{
    public class RolesController : Controller
    {
        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
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

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Roles/Edit/5
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

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Roles/Delete/5
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
