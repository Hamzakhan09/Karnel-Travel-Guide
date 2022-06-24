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
    public class Rest_CatController : Controller
    {
        private KarnelTravelDatabaseEntities db = new KarnelTravelDatabaseEntities();

        // GET: Rest_Cat
        public ActionResult Index()
        {
            return View(db.Rest_Cat.ToList());
        }


        // GET: Rest_Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rest_Cat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestCat_Id,ResCat_Name")] Rest_Cat rest_Cat)
        {
            if (ModelState.IsValid)
            {
                db.Rest_Cat.Add(rest_Cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rest_Cat);
        }

        // GET: Rest_Cat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rest_Cat rest_Cat = db.Rest_Cat.Find(id);
            if (rest_Cat == null)
            {
                return HttpNotFound();
            }
            return View(rest_Cat);
        }

        // POST: Rest_Cat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestCat_Id,ResCat_Name")] Rest_Cat rest_Cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rest_Cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rest_Cat);
        }

        // GET: Rest_Cat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rest_Cat rest_Cat = db.Rest_Cat.Find(id);
            if (rest_Cat == null)
            {
                return HttpNotFound();
            }
            return View(rest_Cat);
        }

        // POST: Rest_Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rest_Cat rest_Cat = db.Rest_Cat.Find(id);
            db.Rest_Cat.Remove(rest_Cat);
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
