using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tutorHut.Models;

namespace tutorHut.Controllers
{
    public class EducationLevelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationLevel
        public ActionResult Index()
        {
            return View(db.EducationLevels.ToList());
        }

        // GET: EducationLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationLevel educationLevel = db.EducationLevels.Find(id);
            if (educationLevel == null)
            {
                return HttpNotFound();
            }
            return View(educationLevel);
        }

        // GET: EducationLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationLevelId,LevelType")] EducationLevel educationLevel)
        {
            if (ModelState.IsValid)
            {
                db.EducationLevels.Add(educationLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationLevel);
        }

        // GET: EducationLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationLevel educationLevel = db.EducationLevels.Find(id);
            if (educationLevel == null)
            {
                return HttpNotFound();
            }
            return View(educationLevel);
        }

        // POST: EducationLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EducationLevelId,LevelType")] EducationLevel educationLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationLevel);
        }

        // GET: EducationLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationLevel educationLevel = db.EducationLevels.Find(id);
            if (educationLevel == null)
            {
                return HttpNotFound();
            }
            return View(educationLevel);
        }

        // POST: EducationLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationLevel educationLevel = db.EducationLevels.Find(id);
            db.EducationLevels.Remove(educationLevel);
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
