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
    public class PatientRecordsController : Controller
    {
        private Group11_007_iCAREDBEntities1 db = new Group11_007_iCAREDBEntities1();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        SqlConnection con2 = new SqlConnection();
        SqlCommand com2 = new SqlCommand();
        SqlDataReader dr2;

        // display patients in current loaction
        void connectionString()
        {
            con.ConnectionString = "data source =LAPTOP-NH1P6QTD;database= Group11_007_iCAREDB;integrated security=SSPI;";
            con2.ConnectionString = "data source =LAPTOP-NH1P6QTD;database= Group11_007_iCAREDB;integrated security=SSPI;";

        }

        public ActionResult Myboard(login login)
        {
            
                connectionString();
                con2.Open();

                com2.Connection = con2;
                com2.CommandText = "select * from PatientRecord join UserPassword on (PatientRecord.userID = UserPassword.ID) where UserPassword.username ='" + login.username + "'";
                dr2 = com2.ExecuteReader();
               // List<PatientRecord> records = new List<PatientRecord>();
                if (dr2.Read())
                {
                     PatientRecord newrecord = db.PatientRecord.Find(dr2.GetString(0));
                     return View("Myboard", newrecord);
                // do
                //{

                //  i = i + 11;
                //records.Add(newrecord);
                //} while (dr2.NextResult());




                }
                else
                {
                    return View("Error2");
                }
           
        }


        // GET: PatientRecords
        public ActionResult Index()
        {
            var patientRecord = db.PatientRecord.Include(p => p.GeoCodes).Include(p => p.iCare_Worker);
            return View(patientRecord.ToList());
        }

        public ActionResult Index2()
        {

            var patientRecord = db.PatientRecord.Include(p => p.GeoCodes).Include(p => p.iCare_Worker);
            return View(patientRecord.ToList());
        }
        public ActionResult Assign(string id)
        {
            //connectionString();
            //con.Open();

            //com.Connection = con;
            //com.CommandText = "update Patientrecord set userID = id";
            //dr = com.ExecuteReader();


            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            //var login_ID = dr.ToString();
            var prof = patientRecord.iCare_Worker.profession;


            if ((prof == "nurse"))
            {
                
                return View("success");
            }
            else
            {
                //do not allow the doctor to assign
                // con.Close();
                return View("Error");

            }
            //          connectionString();
            //        con.Open();
            //      com.Connection = con;
            //    com.CommandText = "select iCare_Worker.ID from iCare_Worker join UserPassword on (iCare_Worker.ID = UserPassword.ID) where UserPassword.username ='" + login.username + "' ";
            //  dr = com.ExecuteReader();


            //update with doctor's userID
            //con2.Open();
            //com2.Connection = con2;
            ////com2.CommandText = "update PatientRecord set userID =@login_ID where ID = @id";
            //SqlCommand cmd = new SqlCommand("update PatientRecord set userID =@login_ID where ID = @id");
            //int rowsAffected = cmd.ExecuteNonQuery();
            // SqlCommand NewCmd = con2.CreateCommand();
            //  con2.Open();
            //NewCmd.Connection = con2;
            //            NewCmd.CommandType = CommandType.Text;
            //          NewCmd.CommandText = "update PatientRecord set userID = @login_ID where ID = @id";
            //        int a = NewCmd.ExecuteNonQuery();
            //      if (a > 0)
            //    {
            //      return View("success");
            //}
            //             else
            //           {
            //             return View("Error");
            //       }




        }

        // display patients in current loaction
        public ActionResult Display(login login)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from PatientRecord where geoID ='1'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("Create");

            }
            else
            {
                con.Close();
                return View("Delete");
            }

        }

        // GET: PatientRecords/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientRecord);
        }

        // GET: PatientRecords/Create
        public ActionResult Create()
        {
            ViewBag.geoID = new SelectList(db.GeoCodes, "ID", "description");
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession");
            return View();
        }

        // POST: PatientRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,address,dateOfBirth,height,weight,bloodGroup,bedID,treatmentArea,geoID,userID")] PatientRecord patientRecord)
        {
            if (ModelState.IsValid)
            {
                db.PatientRecord.Add(patientRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.geoID = new SelectList(db.GeoCodes, "ID", "description", patientRecord.geoID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", patientRecord.userID);
            return View(patientRecord);
        }

        // GET: PatientRecords/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.geoID = new SelectList(db.GeoCodes, "ID", "description", patientRecord.geoID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", patientRecord.userID);
            return View(patientRecord);
        }

        // POST: PatientRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,address,dateOfBirth,height,weight,bloodGroup,bedID,treatmentArea,geoID,userID")] PatientRecord patientRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.geoID = new SelectList(db.GeoCodes, "ID", "description", patientRecord.geoID);
            ViewBag.userID = new SelectList(db.iCare_Worker, "ID", "profession", patientRecord.userID);
            return View(patientRecord);
        }

        // GET: PatientRecords/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientRecord);
        }

        // POST: PatientRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PatientRecord patientRecord = db.PatientRecord.Find(id);
            db.PatientRecord.Remove(patientRecord);
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
