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
    public class iCareUsersController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        // GET: iCareUsers
        public ActionResult Index()
        {
            var iCareUser = db.iCareUser.Include(i => i.iCare_Admin).Include(i => i.iCare_Worker).Include(i => i.UserPassword);
            return View(iCareUser.ToList());
        }

        // GET: iCareUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCareUser iCareUser = db.iCareUser.Find(id);
            if (iCareUser == null)
            {
                return HttpNotFound();
            }
            return View(iCareUser);
        }

        // GET: iCareUsers/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.iCare_Admin, "ID", "ID");
            ViewBag.ID = new SelectList(db.iCare_Worker, "ID", "profession");
            ViewBag.ID = new SelectList(db.UserPassword, "ID", "userName");
            return View();
        }

        // POST: iCareUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] iCareUser iCareUser)
        {
            if (ModelState.IsValid)
            {
                db.iCareUser.Add(iCareUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.iCare_Admin, "ID", "ID", iCareUser.ID);
            ViewBag.ID = new SelectList(db.iCare_Worker, "ID", "profession", iCareUser.ID);
            ViewBag.ID = new SelectList(db.UserPassword, "ID", "userName", iCareUser.ID);
            return View(iCareUser);
        }

        // GET: iCareUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCareUser iCareUser = db.iCareUser.Find(id);
            if (iCareUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.iCare_Admin, "ID", "ID", iCareUser.ID);
            ViewBag.ID = new SelectList(db.iCare_Worker, "ID", "profession", iCareUser.ID);
            ViewBag.ID = new SelectList(db.UserPassword, "ID", "userName", iCareUser.ID);
            return View(iCareUser);
        }

        // POST: iCareUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] iCareUser iCareUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCareUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.iCare_Admin, "ID", "ID", iCareUser.ID);
            ViewBag.ID = new SelectList(db.iCare_Worker, "ID", "profession", iCareUser.ID);
            ViewBag.ID = new SelectList(db.UserPassword, "ID", "userName", iCareUser.ID);
            return View(iCareUser);
        }

        // GET: iCareUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iCareUser iCareUser = db.iCareUser.Find(id);
            if (iCareUser == null)
            {
                return HttpNotFound();
            }
            return View(iCareUser);
        }

        // POST: iCareUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            iCareUser iCareUser = db.iCareUser.Find(id);
            db.iCareUser.Remove(iCareUser);
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
