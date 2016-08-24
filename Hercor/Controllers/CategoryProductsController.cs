using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hercor.Models;

namespace Hercor.Controllers
{
    public class CategoryProductsController : Controller
    {
        private ModelFirst db = new ModelFirst();

        // GET: CategoryProducts
        public ActionResult Index()
        {
            return View(db.CategoryProduct.ToList());
        }

        // GET: CategoryProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryProduct categoryProduct = db.CategoryProduct.Find(id);
            if (categoryProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryProduct);
        }

        // GET: CategoryProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoryProduct,Name,Description,slug")] CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                db.CategoryProduct.Add(categoryProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryProduct);
        }

        // GET: CategoryProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryProduct categoryProduct = db.CategoryProduct.Find(id);
            if (categoryProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryProduct);
        }

        // POST: CategoryProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoryProduct,Name,Description,slug")] CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryProduct);
        }

        // GET: CategoryProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryProduct categoryProduct = db.CategoryProduct.Find(id);
            if (categoryProduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryProduct);
        }

        // POST: CategoryProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryProduct categoryProduct = db.CategoryProduct.Find(id);
            db.CategoryProduct.Remove(categoryProduct);
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
