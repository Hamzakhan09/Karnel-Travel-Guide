using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class BookingsController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        public ActionResult bookingcreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult bookingcreate(Booking booking)
        {
            
            db.Bookings.Add(booking);
            db.SaveChanges();
            return View();
        }
    }
}