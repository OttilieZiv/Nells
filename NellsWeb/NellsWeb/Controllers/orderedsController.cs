using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NellsWeb.Models;

namespace NellsWeb.Controllers
{
    public class orderedsController : Controller
    {
        private NellsEntities db = new NellsEntities();

        // GET: ordereds
        public ActionResult Index()
        {
            var ordereds = db.ordereds.Include(o => o.brand);
            return View(ordereds.ToList());
        }

        // GET: ordereds/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordered ordered = db.ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            return View(ordered);
        }

        // GET: ordereds/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name");
            return View();
        }

        // POST: ordereds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrandID,Name,Description,Notes,DateOrdered,Received")] ordered ordered)
        {
            if (ModelState.IsValid)
            {
                db.ordereds.Add(ordered);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", ordered.BrandID);
            return View(ordered);
        }

        // GET: ordereds/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordered ordered = db.ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", ordered.BrandID);
            return View(ordered);
        }

        // POST: ordereds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandID,Name,Description,Notes,DateOrdered,Received")] ordered ordered)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordered).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", ordered.BrandID);
            return View(ordered);
        }

        // GET: ordereds/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordered ordered = db.ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            return View(ordered);
        }

        // POST: ordereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ordered ordered = db.ordereds.Find(id);
            db.ordereds.Remove(ordered);
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
