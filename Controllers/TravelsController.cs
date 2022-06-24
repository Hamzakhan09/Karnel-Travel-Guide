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
    public class TravelsController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: Travels
        public ActionResult Index()
        {
            if (Session["a_id"] != null)
            {
                return View(db.Travels.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

        // GET: Travels/Create
        public ActionResult Create()
        {
            if (Session["a_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }
        }

        // POST: Travels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Travel travel, HttpPostedFileBase travelimg1, HttpPostedFileBase travelimg2)
        {
            if (ModelState.IsValid)
            {
                if (travelimg1.ContentLength > 0)
                {
                    string fileName1 = travelimg1.FileName;
                    travelimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    travelimg1.InputStream.Close();
                    travelimg1.InputStream.Dispose();

                    if (travelimg2.ContentLength > 0)
                    {
                        string fileName2 = travelimg2.FileName;
                        travelimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        travelimg2.InputStream.Close();
                        travelimg2.InputStream.Dispose();
                        travel.Travel_Image2 = fileName2;
                    }

                    travel.Travel_Image = fileName1;
                    db.Travels.Add(travel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(travel);
        }

        // GET: Travels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travels/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Travel travel,HttpPostedFileBase travelimg1,HttpPostedFileBase travelimg2)
        {
            if (ModelState.IsValid)
            {
                if(travelimg1.ContentLength > 0)
                {
                    string fileName1 = travelimg1.FileName;
                    travelimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    travelimg1.InputStream.Close();
                    travelimg1.InputStream.Dispose();
                   
                    if(travelimg2.ContentLength > 0)
                    {
                        string fileName2 = travelimg2.FileName;
                        travelimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        travelimg2.InputStream.Close();
                        travelimg2.InputStream.Dispose();
                        travel.Travel_Image2 = fileName2;
                    }

                    travel.Travel_Image = fileName1;
                    db.Entry(travel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
               
            }
            return View(travel);
        }

        // GET: Travels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
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
