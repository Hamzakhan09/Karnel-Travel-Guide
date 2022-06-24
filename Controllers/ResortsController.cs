using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class ResortsController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: Resorts
        public ActionResult Index()
        {
            if (Session["a_id"] != null)
            {
                var resorts = db.Resorts.Include(r => r.City);
                return View(resorts.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }
        }


        // GET: Resorts/Create
        public ActionResult Create()
        {
            if (Session["a_id"] != null)
            {
                ViewBag.Resort_City = new SelectList(db.Cities, "City_Id", "City_Name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

        // POST: Resorts/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resort resort,HttpPostedFileBase resortimg1, HttpPostedFileBase resortimg2, HttpPostedFileBase resortimg3)
        {
            if (ModelState.IsValid)
            {
                if(resortimg1.ContentLength > 0)
                {
                    string fileName1 = resortimg1.FileName;
                    resortimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    resortimg1.InputStream.Close();
                    resortimg1.InputStream.Dispose();

                    if(resortimg2.ContentLength > 0)
                    {
                        string fileName2 = resortimg2.FileName;
                        resortimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        resortimg2.InputStream.Close();
                        resortimg2.InputStream.Dispose();
                        resort.Resort_Image2 = fileName2;
                    }

                    if (resortimg3.ContentLength > 0)
                    {
                        string fileName3 = resortimg3.FileName;
                        resortimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        resortimg3.InputStream.Close();
                        resortimg3.InputStream.Dispose();
                        resort.Resort_Image3 = fileName3;
                    }

                    resort.Resort_Image = fileName1;
                    db.Resorts.Add(resort);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
               
            }

            ViewBag.Resort_City = new SelectList(db.Cities, "City_Id", "City_Name", resort.Resort_City);
            return View(resort);
        }

        // GET: Resorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            ViewBag.Resort_City = new SelectList(db.Cities, "City_Id", "City_Name", resort.Resort_City);
            return View(resort);
        }

        // POST: Resorts/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resort resort, HttpPostedFileBase resortimg1, HttpPostedFileBase resortimg2, HttpPostedFileBase resortimg3)
        {
            if (ModelState.IsValid)
            {
                if (resortimg1.ContentLength > 0)
                {
                    string fileName1 = resortimg1.FileName;
                    resortimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    resortimg1.InputStream.Close();
                    resortimg1.InputStream.Dispose();

                    if (resortimg2.ContentLength > 0)
                    {
                        string fileName2 = resortimg2.FileName;
                        resortimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        resortimg2.InputStream.Close();
                        resortimg2.InputStream.Dispose();
                        resort.Resort_Image2 = fileName2;
                    }

                    if (resortimg3.ContentLength > 0)
                    {
                        string fileName3 = resortimg3.FileName;
                        resortimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        resortimg3.InputStream.Close();
                        resortimg3.InputStream.Dispose();
                        resort.Resort_Image3 = fileName3;
                    }

                    resort.Resort_Image = fileName1;
                    db.Entry(resort).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Resort_City = new SelectList(db.Cities, "City_Id", "City_Name", resort.Resort_City);
            return View(resort);
        }

        // GET: Resorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }

        // POST: Resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resort resort = db.Resorts.Find(id);
            db.Resorts.Remove(resort);
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
