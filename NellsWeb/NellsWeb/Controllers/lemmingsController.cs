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
    public class lemmingsController : Controller
    {
        private NellsEntities db = new NellsEntities();

        // GET: lemmings
        public ActionResult Index()
        {
            var lemmings = db.lemmings.Include(l => l.brand);
            return View(lemmings.ToList());
        }

        // GET: lemmings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lemming lemming = db.lemmings.Find(id);
            if (lemming == null)
            {
                return HttpNotFound();
            }
            return View(lemming);
        }

        // GET: lemmings/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name");
            return View();
        }

        // POST: lemmings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrandID,Name,Description,Notes,LustLevel,Killed")] lemming lemming)
        {
            if (ModelState.IsValid)
            {
                db.lemmings.Add(lemming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", lemming.BrandID);
            return View(lemming);
        }

        // GET: lemmings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lemming lemming = db.lemmings.Find(id);
            if (lemming == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", lemming.BrandID);
            return View(lemming);
        }

        // POST: lemmings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandID,Name,Description,Notes,LustLevel,Killed")] lemming lemming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lemming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", lemming.BrandID);
            return View(lemming);
        }

        // GET: lemmings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lemming lemming = db.lemmings.Find(id);
            if (lemming == null)
            {
                return HttpNotFound();
            }
            return View(lemming);
        }

        // POST: lemmings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lemming lemming = db.lemmings.Find(id);
            db.lemmings.Remove(lemming);
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
