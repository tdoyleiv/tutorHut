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
using tutorHut.Classes;
using tutorHut.Models;

namespace tutorHut.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        Hidden hide = new Hidden();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reply
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();

            return View();
        }

        // POST: Reply
        [HttpPost]
        public ActionResult Index(string accept, bool deny)
        {

            

            if (ModelState.IsValid)
            {

                string acceptButton = "accept";
                string denyButton = "deny";

                if (acceptButton == "accept")
                {
                    string email = hide.Email;
                    string subject = "Request Accepted";
                    //string linkName = "Click me for GOOGLE";
                    //string tutorEmail = profile.ApplicationUser.Email;
                    //string tutorFirstName = profile.ProfileFirstName;
                    //string tutorLastName = profile.ProfileLastName;
                    //string tutorPhoneNumber = profile.ProfilePhoneNumber;
                    string tutorEmail = "NewTutorA@gmail.com";
                    string tutorFirstName = "New";
                    string tutorLastName = "TutorA";
                    string tutorPhoneNumber = "123-456-7890";
                    string link = "I have accepted your request here is my contact information : " + tutorEmail + " " + tutorPhoneNumber + " " + tutorFirstName + " " + tutorLastName;

                    MailGun.SendSimpleMessage(email, subject, link);
                    return RedirectToAction("Index");
                }

                if (deny)
                {
                    string email = hide.Email;
                    string subject = "Request Denied";
                    string linkName = "Sorry you have been denied by the tutor.";
                    string link = "<html><body><a href='http://localhost:65515/List\'>" + linkName + "</a></body></html>";

                    MailGun.SendSimpleMessage(email, subject, link);
                    return RedirectToAction("Index");
                }



            }

            return View();
        }




        public ActionResult Accept()
        {

            string email = hide.Email;
            string subject = "Request Accepted";
            //string linkName = "Click me for GOOGLE";
            //string tutorEmail = profile.ApplicationUser.Email;
            //string tutorFirstName = profile.ProfileFirstName;
            //string tutorLastName = profile.ProfileLastName;
            //string tutorPhoneNumber = profile.ProfilePhoneNumber;
            string tutorEmail = "NewTutorA@gmail.com";
            string tutorFirstName = "New";
            string tutorLastName = "TutorA";
            string tutorPhoneNumber = "123-456-7890";
            string link = "I have accepted your request here is my contact information : " + tutorEmail + " " + tutorPhoneNumber + " " + tutorFirstName + " " + tutorLastName;

            MailGun.SendSimpleMessage(email, subject, link);


            return View();
        }



        public ActionResult Deny()
        {

            string email = hide.Email;
            string subject = "Request Denied";
            string link = "I'm sorry your request was denied";

            MailGun.SendSimpleMessage(email, subject, link);

            return View();
        }






    }
}