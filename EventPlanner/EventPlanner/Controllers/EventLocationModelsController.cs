using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Models;
using EventPlanner.Models.EventPlannerModels;

namespace EventPlanner.Controllers.EventPlannerController
{
    public class EventLocationModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventLocationModels
        public ActionResult Index()
        {
            return View(db.EventLocationModels.ToList());
        }
        [HttpPost]
        public ActionResult Index(string SearchResult)

        {
            var ZipCodeSearch = from m in db.EventLocationModels
                                select m;
            if (!string.IsNullOrEmpty(SearchResult))
            {
                ZipCodeSearch = ZipCodeSearch.Where(s => s.ZipCode.ToString().Contains(SearchResult));
            }

            return View(ZipCodeSearch);
        }

        // GET: EventLocationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLocationModel eventLocationModel = db.EventLocationModels.Find(id);
            if (eventLocationModel == null)
            {
                return HttpNotFound();
            }
            return View(eventLocationModel);
        }

        // GET: EventLocationModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLocationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VenueName,Address,ZipCode,City,State,Capacity,Price")] EventLocationModel eventLocationModel)
        {
            if (ModelState.IsValid)
            {
                db.EventLocationModels.Add(eventLocationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventLocationModel);
        }

        // GET: EventLocationModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLocationModel eventLocationModel = db.EventLocationModels.Find(id);
            if (eventLocationModel == null)
            {
                return HttpNotFound();
            }
            return View(eventLocationModel);
        }

        // POST: EventLocationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VenueName,Address,ZipCode,City,State,Capacity,Price")] EventLocationModel eventLocationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventLocationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventLocationModel);
        }

        // GET: EventLocationModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLocationModel eventLocationModel = db.EventLocationModels.Find(id);
            if (eventLocationModel == null)
            {
                return HttpNotFound();
            }
            return View(eventLocationModel);
        }

        // POST: EventLocationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventLocationModel eventLocationModel = db.EventLocationModels.Find(id);
            db.EventLocationModels.Remove(eventLocationModel);
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
