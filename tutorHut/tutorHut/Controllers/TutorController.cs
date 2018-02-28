using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutorHut.Classes;
using tutorHut.Models;

namespace tutorHut.Controllers
{
    public class TutorController : Controller
    {
        Hidden hide = new Hidden();

        // GET: Tutor
        public ActionResult Index()
        {
            return View();
        }

        //POST
        // when you press the button it does this
        [HttpPost]
        public ActionResult Index(string parentEmail, string message)
        {

            string email = hide.Email;
            string subject = "Tutor Update";
            string link = message;


            MailGun.SendSimpleMessage(email, subject, link);

            return View();
        }
    }
}