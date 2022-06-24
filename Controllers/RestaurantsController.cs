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
    public class RestaurantsController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: Restaurants
        public ActionResult Index()
        {
            if (Session["a_id"]!= null)
            {
                var restaurants = db.Restaurants.Include(r => r.City).Include(r => r.Rest_Cat);
                return View(restaurants.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

    

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            if (Session["a_id"] != null)
            {
                ViewBag.Restaurant_City = new SelectList(db.Cities, "City_Id", "City_Name");
                ViewBag.Restaurant_Catagories = new SelectList(db.Rest_Cat, "RestCat_Id", "ResCat_Name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", controllerName: "FrontEnd");
            }

        }

        // POST: Restaurants/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant,HttpPostedFileBase resimg1 , HttpPostedFileBase resimg2, HttpPostedFileBase resimg3)
        {
            if (ModelState.IsValid)
            {
                if(resimg1.ContentLength > 0)
                {
                    string fileName1 = resimg1.FileName;
                    resimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    resimg1.InputStream.Close();
                    resimg1.InputStream.Dispose();

                    if(resimg2.ContentLength > 0)
                    {
                        string fileName2 = resimg2.FileName;
                        resimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        resimg2.InputStream.Close();
                        resimg2.InputStream.Dispose();
                        restaurant.Restaurant_Image2 = fileName2;
                    }

                    if(resimg3.ContentLength > 0)
                    {
                        string fileName3 = resimg3.FileName;
                        resimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        resimg3.InputStream.Close();
                        resimg3.InputStream.Dispose();
                        restaurant.Restaurant_Image3 = fileName3;
                    }

                    restaurant.Restaurant_Image = fileName1;
                    db.Restaurants.Add(restaurant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            ViewBag.Restaurant_City = new SelectList(db.Cities, "City_Id", "City_Name", restaurant.Restaurant_City);
            ViewBag.Restaurant_Catagories = new SelectList(db.Rest_Cat, "RestCat_Id", "ResCat_Name", restaurant.Restaurant_Catagories);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurant_City = new SelectList(db.Cities, "City_Id", "City_Name", restaurant.Restaurant_City);
            ViewBag.Restaurant_Catagories = new SelectList(db.Rest_Cat, "RestCat_Id", "ResCat_Name", restaurant.Restaurant_Catagories);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant,HttpPostedFileBase resimg1 , HttpPostedFileBase resimg2, HttpPostedFileBase resimg3)
        {
            if (ModelState.IsValid)
            {
                if (resimg1.ContentLength > 0)
                {
                    string fileName1 = resimg1.FileName;
                    resimg1.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                    resimg1.InputStream.Close();
                    resimg1.InputStream.Dispose();

                    if (resimg2.ContentLength > 0)
                    {
                        string fileName2 = resimg2.FileName;
                        resimg2.SaveAs(Server.MapPath("~/Content/images/" + fileName2));
                        resimg2.InputStream.Close();
                        resimg2.InputStream.Dispose();
                        restaurant.Restaurant_Image2 = fileName2;
                    }

                    if (resimg3.ContentLength > 0)
                    {
                        string fileName3 = resimg3.FileName;
                        resimg3.SaveAs(Server.MapPath("~/Content/images/" + fileName3));
                        resimg3.InputStream.Close();
                        resimg3.InputStream.Dispose();
                        restaurant.Restaurant_Image3 = fileName3;
                    }

                    restaurant.Restaurant_Image = fileName1;
                    db.Entry(restaurant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Restaurant_City = new SelectList(db.Cities, "City_Id", "City_Name", restaurant.Restaurant_City);
            ViewBag.Restaurant_Catagories = new SelectList(db.Rest_Cat, "RestCat_Id", "ResCat_Name", restaurant.Restaurant_Catagories);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
