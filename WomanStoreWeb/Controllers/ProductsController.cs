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
    public class ProductsController : Controller
    {
        private WemonDbEntities1 db = new WemonDbEntities1();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Color).Include(p => p.Material).Include(p => p.ProductType).Include(p => p.Size);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name");
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductTypeId,ColorId,SizeId,MaterialId,Price,Counter,ImageUrl,Description,CreateTime,UpdateTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", product.SizeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", product.SizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductTypeId,ColorId,SizeId,MaterialId,Price,Counter,ImageUrl,Description,CreateTime,UpdateTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", product.ColorId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", product.MaterialId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", product.SizeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
