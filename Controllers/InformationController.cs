using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class InformationController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        // GET: Information
        public ActionResult TouristSpot()
        {
            var touristSpots = db.TouristSpots;
            return View(touristSpots.ToList());
        }

        public ActionResult Travel()
        {
            var travels = db.Travels;
            return View(travels.ToList());
        }

        public ActionResult Hotel()
        {
            var hotels = db.Hotels;
            return View(hotels.ToList());
        }

        public ActionResult Restaurant()
        {
            var restaurants = db.Restaurants;
            return View(restaurants.ToList());
        }

        public ActionResult Resort()
        {
            var resorts = db.Resorts;
            return View(resorts.ToList());
        }
    }
}