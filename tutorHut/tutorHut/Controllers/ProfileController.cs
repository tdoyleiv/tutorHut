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
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile
        public ActionResult Index()
        {
            var profiles = db.Profiles.Include(p => p.Address).Include(p => p.ApplicationUser).Include(p => p.Request).Include(p => p.Subject);
            return View(profiles.ToList());
        }

        // GET: Profile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "EducationLevelId");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,UserId,AddressId,SubjectId,RequestId,ProfileFirstName,ProfileLastName,ProfilePhoneNumber,HourlyRate,MyDescription")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress", profile.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status", profile.RequestId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "EducationLevelId", profile.SubjectId);
            return View(profile);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress", profile.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status", profile.RequestId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "EducationLevelId", profile.SubjectId);
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,UserId,AddressId,SubjectId,RequestId,ProfileFirstName,ProfileLastName,ProfilePhoneNumber,HourlyRate,MyDescription")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress", profile.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status", profile.RequestId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "EducationLevelId", profile.SubjectId);
            return View(profile);
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
