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
    public class AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        public ActionResult Index()
        {
            // [ 1 ]
            //var Addresses = db.Addresses.Include(a => a.AddressId);
            // [ 1 ] End

            //obtain logged in ID
            //var UserId = User.Identity.GetUserId();
            //var profile = db.Profiles.Where(p => p.UserId == UserId).First();

            //get user id
            //var userID = User.Identity.GetUserId();
            //get the profile that corrolates to that id
            //Profile userProfile = db.Profiles.Where(p => p.UserId == userID).First();
            //userProfile.AddressId = address.AddressId;

            // [ 2 ]
            var userID = User.Identity.GetUserId();
            Profile userProfile = db.Profiles.Where(p => p.UserId == userID).First();
            // [ 2 ] end

            //address id is the id that matchs the user's profile
            // this doesn't exist yet
            //  - create it in the profile controller
            //

            //[ 2 ]
            try
            {
                var Address = db.Addresses.Include(a => a.AddressId == userProfile.AddressId);
                return View(Address);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create");
            }
            //[ 2 ] End

            // [ 1 ] 
            //return View(db.Addresses.ToList());
            // [ 1 ] End

            //return View(userProfile.Address);
            //return View(Address);
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,StreetAddress,City,State,ZipCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                //get whoever is logged in 
                //var userID = User.Identity.GetUserId();
                //get the profile whoever is logged in
                // this gets all the profile table
                // UserId is the FK for ApplicationUsers
                //Profile userProfile = db.Profiles.Where(p => p.UserId == userID).First();
                // created a address Id
                //userProfile.AddressId = address.AddressId;


                //get the user that's logged in
                var userId = User.Identity.GetUserId();
                //get the user's profile
                Profile userProfile = db.Profiles.Where(p => p.UserId == userId).First();
                //this user's profile should be this on the address table
                // ?shouldn't this be in the profile controller?
                //userProfile.Address.AddressId = address.AddressId;

                //address.AddressId = userProfile.ProfileId;
                //sets the usrProfile the streetAddress
                userProfile.AddressId = address.AddressId;

                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,StreetAddress,City,State,ZipCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
