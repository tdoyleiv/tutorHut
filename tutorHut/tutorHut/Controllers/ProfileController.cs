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
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET:  Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var profiles = db.Profiles.Include(p => p.Address).Include(p => p.ApplicationUser).Include(p => p.Request).Include(p => p.Subject);

            profiles = db.Profiles.Where(p => p.UserId == userId).Include(p => p.Address).Include(p => p.ApplicationUser).Include(p => p.Subject);

            //2/var userId = User.Identity.GetUserId();

            //serch for the correct profile
            //2/var profileId = db.Profiles.Where(p => p.UserId == userId);

            //return View(profiles.ToList());
            return View(profiles);
            //2/return View(profileId);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,UserId,AddressId,SubjectId,RequestId,ProfileFirstName,ProfileLastName,ProfilePhoneNumber,HourlyRate,MyDescription")] Profile profile)
        {
            //get user id
            //var UserId = User.Identity.GetUserId();
            //profile.UserId = UserId;

            //obtain the user's id
            var userId = User.Identity.GetUserId();
            //set user's id to FK UserID in Profile
            profile.UserId = userId;
            

            //create a Address with an Id
            // connect address id with profile id
            // I want AddressId to be populated with Profile Id
            //var address = db.Addresses.Include(a => a.AddressId);
            //Address address1;
            //address1.AddressId = profile.ProfileId;
            //profile.AddressId = address1.AddressId;
            //address1.AddressId = profile.AddressId;

            //Address address = db.Addresses.Include(a => a.AddressId == ProfileId);

            //profile.Address.AddressId = address.AddressId;

            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //drop down list
            //ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress", profile.AddressId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            //ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status", profile.RequestId);
            //ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName", profile.SubjectId);

            return View(profile);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName", profile.SubjectId);
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
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName", profile.SubjectId);
            return View(profile);
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
