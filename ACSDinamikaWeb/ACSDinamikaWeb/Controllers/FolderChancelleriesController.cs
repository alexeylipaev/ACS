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
    [Authorize]
    public class FolderChancelleriesController : Controller
    {
        private ACSContext db = new ACSContext();

        // GET: FolderChancelleries
        public ActionResult Index()
        {
            return View(db.FolderChancelleries.ToList());
        }

        // GET: FolderChancelleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolderChancellery folderChancellery = db.FolderChancelleries.Find(id);
            if (folderChancellery == null)
            {
                return HttpNotFound();
            }
            return View(folderChancellery);
        }

        // GET: FolderChancelleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FolderChancelleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] FolderChancellery folderChancellery)
        {
            if (ModelState.IsValid)
            {
                db.FolderChancelleries.Add(folderChancellery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(folderChancellery);
        }

        // GET: FolderChancelleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolderChancellery folderChancellery = db.FolderChancelleries.Find(id);
            if (folderChancellery == null)
            {
                return HttpNotFound();
            }
            return View(folderChancellery);
        }

        // POST: FolderChancelleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] FolderChancellery folderChancellery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folderChancellery).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(folderChancellery);
        }

        // GET: FolderChancelleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FolderChancellery folderChancellery = db.FolderChancelleries.Find(id);
            if (folderChancellery == null)
            {
                return HttpNotFound();
            }
            return View(folderChancellery);
        }

        // POST: FolderChancelleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FolderChancellery folderChancellery = db.FolderChancelleries.Find(id);
            db.FolderChancelleries.Remove(folderChancellery);
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
