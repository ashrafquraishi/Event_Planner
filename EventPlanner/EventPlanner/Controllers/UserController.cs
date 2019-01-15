using EventPlanner.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {

            return View(db.UserModels.ToList());
        }
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult SearchZipcode()
        {
            return View(db.Mains.ToList());
        }
        [HttpPost]
        public ActionResult SearchZipcode(string SearchResult)

        {
            var ZipCodeSearch = from m in db.Mains
                                select m;
            if (!string.IsNullOrEmpty(SearchResult))
            {
                ZipCodeSearch = ZipCodeSearch.Where(s => s.ZipCode.ToString().Contains(SearchResult));
            }

            return View(ZipCodeSearch);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                userModel.ApplicationUserId = userId;
                db.UserModels.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);

        }
        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.UserModels.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Address,ZipCode,City,State")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }


        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.UserModels.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserModel userModel = db.UserModels.Find(id);
            db.UserModels.Remove(userModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
