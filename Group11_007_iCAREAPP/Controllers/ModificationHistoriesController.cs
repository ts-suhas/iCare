using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group11_007_iCAREAPP.Models;

namespace Group11_007_iCAREAPP.Controllers
{
    public class ModificationHistoriesController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        // GET: ModificationHistories
        public ActionResult Index()
        {
            var modificationHistory = db.ModificationHistory.Include(m => m.DocumentMetadata).Include(m => m.iCare_Worker);
            return View(modificationHistory.ToList());
        }

        // GET: ModificationHistories/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Create
        public ActionResult Create()
        {
            ViewBag.docID = new SelectList(db.DocumentMetadata, "docID", "docName");
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession");
            return View();
        }

        // POST: ModificationHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dateofModification,description,docID,userID")] ModificationHistory modificationHistory)
        {
            if (ModelState.IsValid)
            {
                db.ModificationHistory.Add(modificationHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.docID = new SelectList(db.DocumentMetadata, "docID", "docName", modificationHistory.docID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", modificationHistory.userID);
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.docID = new SelectList(db.DocumentMetadata, "docID", "docName", modificationHistory.docID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", modificationHistory.userID);
            return View(modificationHistory);
        }

        // POST: ModificationHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dateofModification,description,docID,userID")] ModificationHistory modificationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modificationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.docID = new SelectList(db.DocumentMetadata, "docID", "docName", modificationHistory.docID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", modificationHistory.userID);
            return View(modificationHistory);
        }

        // GET: ModificationHistories/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            if (modificationHistory == null)
            {
                return HttpNotFound();
            }
            return View(modificationHistory);
        }

        // POST: ModificationHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            ModificationHistory modificationHistory = db.ModificationHistory.Find(id);
            db.ModificationHistory.Remove(modificationHistory);
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
