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
    public class iCare_WorkerController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        // GET: iCare_Worker
        public ActionResult Index()
        {
            var iCare_Worker = db.iCare_Worker.Include(i => i.iCareUser).Include(i => i.UserRole);
            return View(iCare_Worker.ToList());
        }

        // GET: iCare_Worker/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Worker iCare_Worker = db.iCare_Worker.Find(id);
            if (iCare_Worker == null)
            {
                return HttpNotFound();
            }
            return View(iCare_Worker);
        }

        // GET: iCare_Worker/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name");
            ViewBag.userroleID = new SelectList(db.UserRole, "roleID", "roleName");
            return View();
        }

        // POST: iCare_Worker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profession,ID,userroleID")] iCare_Worker iCare_Worker)
        {
            if (ModelState.IsValid)
            {
                db.iCare_Worker.Add(iCare_Worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Worker.ID);
            ViewBag.userroleID = new SelectList(db.UserRole, "roleID", "roleName", iCare_Worker.userroleID);
            return View(iCare_Worker);
        }

        // GET: iCare_Worker/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Worker iCare_Worker = db.iCare_Worker.Find(id);
            if (iCare_Worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Worker.ID);
            ViewBag.userroleID = new SelectList(db.UserRole, "roleID", "roleName", iCare_Worker.userroleID);
            return View(iCare_Worker);
        }

        // POST: iCare_Worker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profession,ID,userroleID")] iCare_Worker iCare_Worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCare_Worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", iCare_Worker.ID);
            ViewBag.userroleID = new SelectList(db.UserRole, "roleID", "roleName", iCare_Worker.userroleID);
            return View(iCare_Worker);
        }

        // GET: iCare_Worker/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCare_Worker iCare_Worker = db.iCare_Worker.Find(id);
            if (iCare_Worker == null)
            {
                return HttpNotFound();
            }
            return View(iCare_Worker);
        }

        // POST: iCare_Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            iCare_Worker iCare_Worker = db.iCare_Worker.Find(id);
            db.iCare_Worker.Remove(iCare_Worker);
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
