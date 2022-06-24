using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class AdminController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Admin dashboard login with session
        public ActionResult AdminDashboard()
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
    }
}