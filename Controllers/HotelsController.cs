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
    public class HotelsController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: Hotels
        public ActionResult Index()
        {
            if (Session["a_id"] != null)
            {
                var hotels = db.Hotels.Include(h => h.City);
                return View(hotels.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

       

        // GET: Hotels/Create
        public ActionResult Create()
        {
            if (Session["a_id"] != null)
            {
                ViewBag.Hotel_City = new SelectList(db.Cities, "City_Id", "City_Name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

        // POST: Hotels/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel,HttpPostedFileBase hotelimg1,HttpPostedFileBase hotelimg2,HttpPostedFileBase hotelimg3)
        {
            if (ModelState.IsValid)
            {
                if (hotelimg1.ContentLength > 0)
                {

                    string fileName1 = hotelimg1.FileName;
                    hotelimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    hotelimg1.InputStream.Close();
                    hotelimg1.InputStream.Dispose();


                    if (hotelimg2.ContentLength > 0)
                    {
                        string fileName2 = hotelimg2.FileName;
                        hotelimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        hotelimg2.InputStream.Close();
                        hotelimg2.InputStream.Dispose();
                        hotel.Hotel_Image2 = fileName2;
                    }

                    if(hotelimg3.ContentLength > 0)
                    {
                        string fileName3 = hotelimg3.FileName;
                        hotelimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        hotelimg3.InputStream.Close();
                        hotelimg3.InputStream.Dispose();
                        hotel.Hotel_Image3 = fileName3;
                    }
                    hotel.Hotel_Image = fileName1;
                    db.Hotels.Add(hotel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Hotel_City = new SelectList(db.Cities, "City_Id", "City_Name", hotel.Hotel_City);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hotel_City = new SelectList(db.Cities, "City_Id", "City_Name", hotel.Hotel_City);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotel hotel, HttpPostedFileBase hotelimg1, HttpPostedFileBase hotelimg2, HttpPostedFileBase hotelimg3)
        {
            if (ModelState.IsValid)
            {
                if (hotelimg1.ContentLength > 0)
                {

                    string fileName1 = hotelimg1.FileName;
                    hotelimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    hotelimg1.InputStream.Close();
                    hotelimg1.InputStream.Dispose();


                    if (hotelimg2.ContentLength > 0)
                    {
                        string fileName2 = hotelimg2.FileName;
                        hotelimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        hotelimg2.InputStream.Close();
                        hotelimg2.InputStream.Dispose();
                        hotel.Hotel_Image2 = fileName2;
                    }

                    if (hotelimg3.ContentLength > 0)
                    {
                        string fileName3 = hotelimg3.FileName;
                        hotelimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        hotelimg3.InputStream.Close();
                        hotelimg3.InputStream.Dispose();
                        hotel.Hotel_Image3 = fileName3;
                    }
                    hotel.Hotel_Image = fileName1;

                    db.Entry(hotel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Hotel_City = new SelectList(db.Cities, "City_Id", "City_Name", hotel.Hotel_City);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
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
