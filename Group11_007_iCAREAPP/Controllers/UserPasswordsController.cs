using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group11_007_iCAREAPP.Models;
using System.Data.SqlClient;

namespace Group11_007_iCAREAPP.Controllers
{
    public class UserPasswordsController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
      

        // Verify UserPasswords
        void connectionString()
        {
            con.ConnectionString = "data source =LAPTOP-NH1P6QTD;database= Group11_007_iCAREDB;integrated security=SSPI;";
         

        }

        // Verify UserPasswords
        [HttpPost]
        public ActionResult Verify(login login)
        {
            connectionString();
            con.Open();
         

            com.Connection = con;
        

            com.CommandText = "select * from UserPassword where userName='" + login.username + "' and encryptedPassword='" + login.password + "'";
          
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();

                if ((login.username == "admin@group11") && (login.password == "password@group11"))
                {
                    return View("AdminPage");
                }
                else
                {
                    
                    return View("WorkerPage",login);
                }


            }
            else
            {
                con.Close();
                return View("Error");
            }

        }

        // GET: UserPasswords
        public ActionResult Index()
        {
            var userPassword = db.UserPassword.Include(u => u.iCareUser);
            return View(userPassword.ToList());
        }

        // GET: UserPasswords/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword userPassword = db.UserPassword.Find(id);
            if (userPassword == null)
            {
                return HttpNotFound();
            }
            return View(userPassword);
        }

        // GET: UserPasswords/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name");
            return View();
        }

        // POST: UserPasswords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,userName,encryptedPassword,passwordExpiryTime,userAccountExpiryDate")] UserPassword userPassword)
        {
            if (ModelState.IsValid)
            {
                db.UserPassword.Add(userPassword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", userPassword.ID);
            return View(userPassword);
        }

        // GET: UserPasswords/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword userPassword = db.UserPassword.Find(id);
            if (userPassword == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", userPassword.ID);
            return View(userPassword);
        }

        // POST: UserPasswords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,userName,encryptedPassword,passwordExpiryTime,userAccountExpiryDate")] UserPassword userPassword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPassword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.iCareUser, "ID", "Name", userPassword.ID);
            return View(userPassword);
        }

        // GET: UserPasswords/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPassword userPassword = db.UserPassword.Find(id);
            if (userPassword == null)
            {
                return HttpNotFound();
            }
            return View(userPassword);
        }

        // POST: UserPasswords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserPassword userPassword = db.UserPassword.Find(id);
            db.UserPassword.Remove(userPassword);
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
