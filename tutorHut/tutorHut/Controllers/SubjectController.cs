using Microsoft.AspNet.Identity;
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
    public class SubjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subject
        public ActionResult Index()
        {
            // [ 1 ]
            //var subjects = db.Subjects.Include(s => s.EducationLevel);
            //[ 1 ] end


            // [ 2 ]
            var userID = User.Identity.GetUserId();
            Profile userProfile = db.Profiles.Where(p => p.UserId == userID).First();
            // [ 2 ] end



            //[ 2 ]
            try
            {
                var subjects = db.Subjects.Include(a => a.SubjectID == userProfile.AddressId);
                return View(subjects);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create");
            }
            //[ 2 ] End



            // [ 1 ]
            //return View(subjects.ToList());
            // [ 1 ] end

        }

        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "EducationLevelId", "LevelType");
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,EducationLevelId,SubjectName")] Subject subject)
        {
            if (ModelState.IsValid)
            {

                //get the user that's logged in
                var userId = User.Identity.GetUserId();
                //get the user's profile
                Profile userProfile = db.Profiles.Where(p => p.UserId == userId).First();

                //sets the usrProfile the subjectId
                userProfile.SubjectId = subject.SubjectID;



                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "EducationLevelId", "LevelType", subject.EducationLevelId);
            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "EducationLevelId", "LevelType", subject.EducationLevelId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,EducationLevelId,SubjectName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "EducationLevelId", "LevelType", subject.EducationLevelId);
            return View(subject);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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
