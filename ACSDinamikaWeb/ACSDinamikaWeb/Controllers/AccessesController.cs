using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACSDinamikaWeb.Models.EF.CFFromDB;

namespace ACSDinamikaWeb.Controllers
{
    public class AccessesController : Controller
    {
        private ACSContext db = new ACSContext();

        // GET: Accesses
        public ActionResult Index()
        {
            var accesses = db.Accesses.Include(a => a.TypeAccess);
            return View(accesses.ToList());
        }

        // GET: Accesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            return View(access);
        }

        // GET: Accesses/Create
        public ActionResult Create()
        {
            ViewBag.TypeAccessId = new SelectList(db.TypeAccesses, "Id", "Name");
            return View();
        }

        // POST: Accesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserGuid1C,GuidObject,TypeAccessId,Value,Note,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] Access access)
        {
            if (ModelState.IsValid)
            {
                access.Id = 1;
                db.Accesses.Add(access);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeAccessId = new SelectList(db.TypeAccesses, "Id", "Name", access.TypeAccessId);
            return View(access);
        }

        // GET: Accesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeAccessId = new SelectList(db.TypeAccesses, "Id", "Name", access.TypeAccessId);
            return View(access);
        }

        // POST: Accesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserGuid1C,GuidObject,TypeAccessId,Value,Note,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] Access access)
        {
            if (ModelState.IsValid)
            {
                db.Entry(access).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeAccessId = new SelectList(db.TypeAccesses, "Id", "Name", access.TypeAccessId);
            return View(access);
        }

        // GET: Accesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return HttpNotFound();
            }
            return View(access);
        }

        // POST: Accesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Access access = db.Accesses.Find(id);
            db.Accesses.Remove(access);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
