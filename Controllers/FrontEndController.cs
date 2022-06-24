using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class FrontEndController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        public IEnumerable<Travel> tr;
        public IEnumerable<Hotel> he;

        public ActionResult Home()
        {
            return View();
        }

     
        public ActionResult Search(string searchBy,string search)
        {
            if (searchBy == "Tour_Designation")
            {
                var model = db.TouristSpots.Where(x => x.Tour_Designation == search || search == null).ToList();
                return View(model);
            }
            else
            {
                var model = db.TouristSpots.Where(x => x.Tour_Price == search || search == null).ToList();
                return View(model);

            }
            return View(db.TouristSpots.ToList());
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(Cust_FeedBack cust_FeedBack)
        {
            db.Cust_FeedBack.Add(cust_FeedBack);
            db.SaveChanges();
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {
            var user = db.User_Registration.Where(x => x.UserReg_Email == email && x.UserReg_Password == password).FirstOrDefault();
            var admin = db.Admins.Where(x => x.Admin_Email == email && x.Admin_Password == password).FirstOrDefault();
            if (user != null)
            {
                Session["u_img"] = user.UserReg_Image;
                Session["u_id"] = user.UserReg_Id;
                Session["u_name"] = user.UserReg_UserName;
                return RedirectToAction("Home", "FrontEnd");
            }
            else if (admin != null)
            {
                Session["a_id"] = admin.Admin_Id;
                Session["a_name"] = admin.AdminName;
                return RedirectToAction("AdminDashboard", "Admin");
            }
            ViewBag.msg = "Invalid Crenditeals";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Home", "FrontEnd");
        }




        public PartialViewResult partial_1()
        {

            tr = db.Travels.ToList();
            return PartialView("partial_1", tr);

        }


        public PartialViewResult partial_2()
        {

            he = db.Hotels.ToList();
            return PartialView("partial_2", he);

        }


    


    }
}