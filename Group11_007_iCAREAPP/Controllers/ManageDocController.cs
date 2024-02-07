﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using Group11_007_iCAREAPP.Models;

namespace Group11_007_iCAREAPP.Controllers
{
    public class ManageDocController : Controller
    {
        // GET: ManageDoc
        public ActionResult Index()
        {
            List<UploadDocument> UploadDocuments = new List<UploadDocument>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
            {
                FileInfo fi = new FileInfo(strfile);
                UploadDocument obj = new UploadDocument();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                UploadDocuments.Add(obj);
            }

            return View(UploadDocuments);
        }
        public ActionResult Pallete()
        {
            List<UploadDocument> UploadDocuments = new List<UploadDocument>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
            {
                FileInfo fi = new FileInfo(strfile);
                UploadDocument obj = new UploadDocument();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                UploadDocuments.Add(obj);
            }

            return View(UploadDocuments);
        }

            public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Text Document";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public ActionResult Index(UploadDocument doc)
        {
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                    /*DocMetaData.DocName = fileName; */
                }
            }
            TempData["Message"] = "files uploaded successfully";
            return RedirectToAction("Index");
        }

    }
}