using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karnel_Travel_Guide.Models;

namespace Karnel_Travel_Guide.Controllers
{
    public class UserRegController : Controller
    {
        KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();
        // GET: UserReg
        public ActionResult UserSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserSignup(User_Registration user_Registration,HttpPostedFileBase userimg)
        {
            if(userimg.ContentLength > 0)
            {
                string fileName1 = userimg.FileName;
                userimg.SaveAs(Server.MapPath("~/Content/images/" + fileName1));
                userimg.InputStream.Close();
                userimg.InputStream.Dispose();
                user_Registration.UserReg_Image = fileName1;

                db.User_Registration.Add(user_Registration);
                db.SaveChanges();
                return RedirectToAction("LogIn", "FrontEnd");
            }
            
            return View(user_Registration);
        }
    }
}