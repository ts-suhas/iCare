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
    public class iCare_AdminController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        // GET: iCare_Admin
        public ActionResult Index()
        {
            var iCare_Admin = db.iCare_Admin.Include(i => i.iCareUser);
            return View(iCare_Admin.ToList());
        }

        // GET: iCare_Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Admin iCare_Admin = db.iCare_Admin.Find(id);
            if (iCare_Admin == null)
            {
                return HttpNotFound();
            }
            return View(iCare_Admin);
        }

        // GET: iCare_Admin/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name");
            return View();
        }

        // POST: iCare_Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dateHired,dateFinished,ID")] iCare_Admin iCare_Admin)
        {
            if (ModelState.IsValid)
            {
                db.iCare_Admin.Add(iCare_Admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Admin.ID);
            return View(iCare_Admin);
        }

        // GET: iCare_Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Admin iCare_Admin = db.iCare_Admin.Find(id);
            if (iCare_Admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Admin.ID);
            return View(iCare_Admin);
        }

        // POST: iCare_Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dateHired,dateFinished,ID")] iCare_Admin iCare_Admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCare_Admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Admin.ID);
            return View(iCare_Admin);
        }

        // GET: iCare_Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Admin iCare_Admin = db.iCare_Admin.Find(id);
            if (iCare_Admin == null)
            {
                return HttpNotFound();
            }
            return View(iCare_Admin);
        }

        // POST: iCare_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            iCare_Admin iCare_Admin = db.iCare_Admin.Find(id);
            db.iCare_Admin.Remove(iCare_Admin);
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
