using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class DetailsController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        // GET: Details
        public ActionResult Tourist_Detail(int id)
        {
            TouristSpot touristSpot = db.TouristSpots.Where(x => x.Tour_Id == id).SingleOrDefault();
            return View(touristSpot);
        }

        public ActionResult Travel_Detail(int id)
        {
            Travel travel = db.Travels.Where(x => x.Tavel_Id == id).FirstOrDefault();
            return View(travel);
        }

        public ActionResult Hotel_Detail(int id)
        {
            Hotel hotel = db.Hotels.Where(x => x.Hotel_Id == id).FirstOrDefault();
            return View(hotel);
        }

        public ActionResult Restaurant_Detail(int id)
        {
            Restaurant restaurant = db.Restaurants.Where(x => x.Restaurant_Id == id).FirstOrDefault();
            return View(restaurant);
        }

        public ActionResult Resort_Detail(int id)
        {
            Resort resort = db.Resorts.Where(x => x.Resort_Id == id).FirstOrDefault();
            return View(resort);
        }
    }
}