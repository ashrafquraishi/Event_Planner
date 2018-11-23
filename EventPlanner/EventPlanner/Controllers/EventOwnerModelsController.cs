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
    public class EventOwnerModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventOwnerModels
        public ActionResult Index()
        {
            var eventOwnerModels = db.EventOwnerModels.Include(e => e.EventLocationModel);
            return View(eventOwnerModels.ToList());
        }

        // GET: EventOwnerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOwnerModel eventOwnerModel = db.EventOwnerModels.Find(id);
            if (eventOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(eventOwnerModel);
        }

        // GET: EventOwnerModels/Create
        public ActionResult Create()
        {
            ViewBag.EventLocationModelId = new SelectList(db.EventLocationModels, "Id", "VenueName");
            return View();
        }

        // POST: EventOwnerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State,EventLocationModelId")] EventOwnerModel eventOwnerModel)
        {
            if (ModelState.IsValid)
            {
                db.EventOwnerModels.Add(eventOwnerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventLocationModelId = new SelectList(db.EventLocationModels, "Id", "VenueName", eventOwnerModel.EventLocationModelId);
            return View(eventOwnerModel);
        }

        // GET: EventOwnerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOwnerModel eventOwnerModel = db.EventOwnerModels.Find(id);
            if (eventOwnerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventLocationModelId = new SelectList(db.EventLocationModels, "Id", "VenueName", eventOwnerModel.EventLocationModelId);
            return View(eventOwnerModel);
        }

        // POST: EventOwnerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State,EventLocationModelId")] EventOwnerModel eventOwnerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventOwnerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventLocationModelId = new SelectList(db.EventLocationModels, "Id", "VenueName", eventOwnerModel.EventLocationModelId);
            return View(eventOwnerModel);
        }

        // GET: EventOwnerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOwnerModel eventOwnerModel = db.EventOwnerModels.Find(id);
            if (eventOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(eventOwnerModel);
        }

        // POST: EventOwnerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventOwnerModel eventOwnerModel = db.EventOwnerModels.Find(id);
            db.EventOwnerModels.Remove(eventOwnerModel);
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
