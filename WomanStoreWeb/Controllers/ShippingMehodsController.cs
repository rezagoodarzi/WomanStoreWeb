using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WomanStoreWeb.Models;

namespace WomanStoreWeb.Controllers
{
    public class ShippingMehodsController : Controller
    {
        private WemonDbEntities1 db = new WemonDbEntities1();

        // GET: ShippingMehods
        public ActionResult Index()
        {
            return View(db.ShippingMehods.ToList());
        }

        // GET: ShippingMehods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMehod shippingMehod = db.ShippingMehods.Find(id);
            if (shippingMehod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMehod);
        }

        // GET: ShippingMehods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingMehods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Method")] ShippingMehod shippingMehod)
        {
            if (ModelState.IsValid)
            {
                db.ShippingMehods.Add(shippingMehod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingMehod);
        }

        // GET: ShippingMehods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMehod shippingMehod = db.ShippingMehods.Find(id);
            if (shippingMehod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMehod);
        }

        // POST: ShippingMehods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Method")] ShippingMehod shippingMehod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingMehod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingMehod);
        }

        // GET: ShippingMehods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMehod shippingMehod = db.ShippingMehods.Find(id);
            if (shippingMehod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMehod);
        }

        // POST: ShippingMehods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingMehod shippingMehod = db.ShippingMehods.Find(id);
            db.ShippingMehods.Remove(shippingMehod);
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
