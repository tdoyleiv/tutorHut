using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using tutorHut.Models;

namespace tutorHut.Controllers
{
    public class ListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: List
        // added string searchString
        public ActionResult Index(string searchString)
        {
            var profiles = db.Profiles.Include(p => p.Address).Include(p => p.ApplicationUser).Include(p => p.Request).Include(p => p.Subject);

            //addded if statement
            if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(p => p.Subject.SubjectName.Contains(searchString));
            }
            

            return View(profiles.ToList());
        }




        // GET: List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            //Profile profile = db.Profiles.Find(id);

            //new code
            Profile profile = db.Profiles.Include(d => d.Subject).Include(d => d.ApplicationUser).Where(d => d.ProfileId == id).First();

            //this code works!
            //DonationBox donationBoxes = db.DonationBoxes.Include(d => d.ApplicationUser).Include(d => d.DonationBoxCategory).Where(n => n.DonationBoxId == id).First();


            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }



        //new code
        //POST
        [HttpPost]
        public ActionResult Details()
        {
            //new code 2/13 obtain user login          
            var userId = User.Identity.GetUserId();
            //new code 2/13 obtain user login table for email
            ApplicationUser user = db.Users.Where(d => d.Id == userId).First();


            //new code to send email
            if (ModelState.IsValid)
            {
                // 2/13
                string userEmail = user.Email;

                string linkName = "REPLY";
                //string text = "A student/parent wishes to obtain your contact information. Please click on the link to accept or deny this request";
                string text = "\n\n" + userEmail.ToString() + " \n\nwishes to obtain your contact information. Please click on the REPLY link above to accept or deny this request";


                string email = "LanceYang15@gmail.com";               
                string subject = "Request Information";
                string link = "<html><body><a href='http://localhost:65515/Reply\'>" + linkName + "</a></body></html>";


                link += text;


                MailGun.SendSimpleMessage(email, subject, link);


                return RedirectToAction("Index");

            }


            return View();
            //return Content(result);
        }


        //====




        //new code ====

        //GET
        //public ActionResult AcceptOrDecline()
        //{
        //    return View();
        //}


        ////POST
        //[HttpPost]
        //public ActionResult AcceptOrDecline([Bind(Include = "ProfileId,UserId,AddressId,SubjectId,RequestId,ProfileFirstName,ProfileLastName,ProfilePhoneNumber,HourlyRate,MyDescription")] Profile profile)
        //{


        //    return View();
        //}

        //==== [ END ] 




        // GET: List/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "StreetAddress");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.RequestId = new SelectList(db.Requests, "RequestId", "Status");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: List/Create
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
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectID", "SubjectName", profile.SubjectId);
            return View(profile);
        }

        // GET: List/Edit/5
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

        // POST: List/Edit/5
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

        // GET: List/Delete/5
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

        // POST: List/Delete/5
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
