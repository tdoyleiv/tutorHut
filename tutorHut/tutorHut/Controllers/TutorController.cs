using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutorHut.Models;

namespace tutorHut.Controllers
{
    public class TutorController : Controller
    {
        // GET: Tutor
        public ActionResult Index()
        {
            return View();
        }

        //POST 
        [HttpPost]
        public ActionResult Index(string parentEmail, string message)
        {

            string email = "LanceYang15@gmail.com";
            string subject = "Tutor Update";
            string link = message;


            MailGun.SendSimpleMessage(email, subject, link);

            return View();
        }
    }
}