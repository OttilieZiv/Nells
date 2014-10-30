using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NellsWeb.Models;
using PagedList;

namespace NellsWeb.Controllers
{
    public class bottlesController : Controller
    {
        private NellsEntities db = new NellsEntities();

        // GET: bottles
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = string.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var bottles = db.bottles.Include(b => b.brand).Include(b => b.drawer);

            //let's try to get rid of purged ones - will this even work?!
            //hell yes! woo! Am sure there's a more efficient way but we can come to that later...
            var livebottles = from b in bottles
                              where b.Purged == false
                              select b;

            //lazy-ass searching, one day I'll work out how to do it *properly*
            if(!string.IsNullOrEmpty(searchString))
            {
                livebottles = livebottles.Where(b => b.Name.ToLower().Contains(searchString.ToLower())
                    || b.brand.Name.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "ID_desc":
                    livebottles = livebottles.OrderByDescending(b => b.ID);
                    break;
                case "brand_desc":
                    livebottles = livebottles.OrderByDescending(b => b.brand.Name);
                    break;
                case "Brand":
                    livebottles = livebottles.OrderBy(b => b.brand.Name);
                    break;
                case "name_desc":
                    livebottles = livebottles.OrderByDescending(b => b.Name);
                    break;
                case "Name":
                    livebottles = livebottles.OrderBy(b => b.Name);
                    break;
                case "date_desc":
                    livebottles = livebottles.OrderByDescending(b => b.DateAcquired);
                    break;
                case "Date":
                    livebottles = livebottles.OrderBy(b => b.DateAcquired);
                    break;
                default:
                    livebottles = livebottles.OrderBy(b => b.ID);
                    break;
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(livebottles.ToPagedList(pageNumber, pageSize));
            //return View(livebottles.ToList());
            //return View(bottles.ToList());
        }

        // GET: bottles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bottle bottle = db.bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // GET: bottles/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name");
            ViewBag.SwatchDrawer = new SelectList(db.drawers, "ID", "DrawerName");
            return View();
        }

        // POST: bottles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,Name,Description,SwatchNotes,SwatchCoats,SwatchDrawer,DateAcquired,Used,Purged,Goon")] bottle bottle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.bottles.Add(bottle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", bottle.BrandID);
                ViewBag.SwatchDrawer = new SelectList(db.drawers, "ID", "DrawerName", bottle.SwatchDrawer);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "It done fucked up dude");
            }
            return View(bottle);
        }

        // GET: bottles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bottle bottle = db.bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", bottle.BrandID);
            ViewBag.SwatchDrawer = new SelectList(db.drawers, "ID", "DrawerName", bottle.SwatchDrawer);
            return View(bottle);
        }

        // POST: bottles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandID,Name,Description,SwatchNotes,SwatchCoats,SwatchDrawer,DateAcquired,Used,Purged,Goon")] bottle bottle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bottle).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.BrandID = new SelectList(db.brands, "ID", "Name", bottle.BrandID);
                ViewBag.SwatchDrawer = new SelectList(db.drawers, "ID", "DrawerName", bottle.SwatchDrawer);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "It done fucked up dude");
            }
            return View(bottle);
        }

        // GET: bottles/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists start fuckin' prayin'.";
            }
            bottle bottle = db.bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // POST: bottles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bottle bottle = db.bottles.Find(id);
                db.bottles.Remove(bottle);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
