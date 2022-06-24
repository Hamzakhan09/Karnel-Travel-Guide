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
    public class TouristSpotsController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: TouristSpots
        public ActionResult Index()
        {
            if(Session["a_id"] != null)
            {
                var touristSpots = db.TouristSpots.Include(t => t.City);
                return View(touristSpots.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }
          
        }

        

        // GET: TouristSpots/Create
        public ActionResult Create()
        {
            if(Session["a_id"]!= null)
            {
                ViewBag.Tour_City = new SelectList(db.Cities, "City_Id", "City_Name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

        // POST: TouristSpots/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TouristSpot touristSpot, HttpPostedFileBase tourimg1, HttpPostedFileBase tourimg2, HttpPostedFileBase tourimg3)
        {
            if (ModelState.IsValid)
            {
                if (tourimg1.ContentLength > 0)
                {
                    string fileName1 = tourimg1.FileName;
                    tourimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    tourimg1.InputStream.Close();
                    tourimg1.InputStream.Dispose();

                    if (tourimg2.ContentLength > 0)
                    {
                        string fileName2 = tourimg2.FileName;
                        tourimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        tourimg2.InputStream.Close();
                        tourimg2.InputStream.Dispose();
                        touristSpot.Tour_Image2 = fileName2;
                    }

                    if (tourimg3.ContentLength > 0)
                    {
                        string fileName3 = tourimg3.FileName;
                        tourimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        tourimg3.InputStream.Close();
                        tourimg3.InputStream.Dispose();
                        touristSpot.Tour_Image3 = fileName3;
                    }

                    touristSpot.Tour_Image = fileName1;
                    db.TouristSpots.Add(touristSpot);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }

            ViewBag.Tour_City = new SelectList(db.Cities, "City_Id", "City_Name", touristSpot.Tour_City);
            return View(touristSpot);
        }

        // GET: TouristSpots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tour_City = new SelectList(db.Cities, "City_Id", "City_Name", touristSpot.Tour_City);
            return View(touristSpot);
        }

        // POST: TouristSpots/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TouristSpot touristSpot,HttpPostedFileBase tourimg1, HttpPostedFileBase tourimg2, HttpPostedFileBase tourimg3)
        {
            if (ModelState.IsValid)
            {
                if(tourimg1.ContentLength > 0)
                {
                    string fileName1 = tourimg1.FileName;
                    tourimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    tourimg1.InputStream.Close();
                    tourimg1.InputStream.Dispose();

                  if(tourimg2.ContentLength > 0)
                    {
                        string fileName2 = tourimg2.FileName;
                        tourimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        tourimg2.InputStream.Close();
                        tourimg2.InputStream.Dispose();
                        touristSpot.Tour_Image2 = fileName2;
                    }

                  if(tourimg3.ContentLength > 0)
                    {
                        string fileName3 = tourimg3.FileName;
                        tourimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        tourimg3.InputStream.Close();
                        tourimg3.InputStream.Dispose();
                        touristSpot.Tour_Image3 = fileName3;
                    }

                    touristSpot.Tour_Image = fileName1;
                    db.Entry(touristSpot).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.Tour_City = new SelectList(db.Cities, "City_Id", "City_Name", touristSpot.Tour_City);
            return View(touristSpot);
        }

        // GET: TouristSpots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            if (touristSpot == null)
            {
                return HttpNotFound();
            }
            return View(touristSpot);
        }

        // POST: TouristSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Find(id);
            db.TouristSpots.Remove(touristSpot);
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
