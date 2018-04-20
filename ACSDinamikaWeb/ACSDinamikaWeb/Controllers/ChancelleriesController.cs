using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACSWeb.Models.EF.CFFromDB;

namespace ACSWeb.Controllers
{
    public class ChancelleriesController : Controller
    {
        private ACSContext db = new ACSContext();

        // GET: Chancelleries
        public ActionResult Index()
        {
            var chancelleries = db.Chancelleries.Include(c => c.FolderChancellery).Include(c => c.JournalRegistrationsChancellery).Include(c => c.TypeRecordChancellery).Include(c => c.User);
            return View(chancelleries.ToList());
        }

        // GET: Chancelleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chancellery chancellery = db.Chancelleries.Find(id);
            if (chancellery == null)
            {
                return HttpNotFound();
            }
            return View(chancellery);
        }

        // GET: Chancelleries/Create
        public ActionResult Create()
        {
            ViewBag.FolderId = new SelectList(db.FolderChancelleries, "Id", "Name");
            ViewBag.JournalRegistrationsId = new SelectList(db.JournalRegistrationsChancelleries, "Id", "Name");
            ViewBag.TypeRecordId = new SelectList(db.TypeRecordChancelleries, "Id", "Name");
            ViewBag.ResponsibleUserId = new SelectList(db.Users, "Id", "FName");
            return View();
        }

        // POST: Chancelleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeRecordId,DateRegistration,Summary,RegistrationNumber,JournalRegistrationsId,FolderId,ResponsibleUserId,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] Chancellery chancellery)
        {
            if (ModelState.IsValid)
            {
                db.Chancelleries.Add(chancellery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FolderId = new SelectList(db.FolderChancelleries, "Id", "Name", chancellery.FolderId);
            ViewBag.JournalRegistrationsId = new SelectList(db.JournalRegistrationsChancelleries, "Id", "Name", chancellery.JournalRegistrationsId);
            ViewBag.TypeRecordId = new SelectList(db.TypeRecordChancelleries, "Id", "Name", chancellery.TypeRecordId);
            ViewBag.ResponsibleUserId = new SelectList(db.Users, "Id", "FName", chancellery.ResponsibleUserId);
            return View(chancellery);
        }

        // GET: Chancelleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chancellery chancellery = db.Chancelleries.Find(id);
            if (chancellery == null)
            {
                return HttpNotFound();
            }
            ViewBag.FolderId = new SelectList(db.FolderChancelleries, "Id", "Name", chancellery.FolderId);
            ViewBag.JournalRegistrationsId = new SelectList(db.JournalRegistrationsChancelleries, "Id", "Name", chancellery.JournalRegistrationsId);
            ViewBag.TypeRecordId = new SelectList(db.TypeRecordChancelleries, "Id", "Name", chancellery.TypeRecordId);
            ViewBag.ResponsibleUserId = new SelectList(db.Users, "Id", "FName", chancellery.ResponsibleUserId);
            return View(chancellery);
        }

        // POST: Chancelleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeRecordId,DateRegistration,Summary,RegistrationNumber,JournalRegistrationsId,FolderId,ResponsibleUserId,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] Chancellery chancellery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chancellery).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FolderId = new SelectList(db.FolderChancelleries, "Id", "Name", chancellery.FolderId);
            ViewBag.JournalRegistrationsId = new SelectList(db.JournalRegistrationsChancelleries, "Id", "Name", chancellery.JournalRegistrationsId);
            ViewBag.TypeRecordId = new SelectList(db.TypeRecordChancelleries, "Id", "Name", chancellery.TypeRecordId);
            ViewBag.ResponsibleUserId = new SelectList(db.Users, "Id", "FName", chancellery.ResponsibleUserId);
            return View(chancellery);
        }

        // GET: Chancelleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chancellery chancellery = db.Chancelleries.Find(id);
            if (chancellery == null)
            {
                return HttpNotFound();
            }
            return View(chancellery);
        }

        // POST: Chancelleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chancellery chancellery = db.Chancelleries.Find(id);
            db.Chancelleries.Remove(chancellery);
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
