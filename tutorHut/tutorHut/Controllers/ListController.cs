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
    public class ListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: List
        public ActionResult Index()
        {

            var profiles = db.Profiles.Include(p => p.Address).Include(p => p.ApplicationUser).Include(p => p.Request).Include(p => p.Subject);

            return View(profiles);
        }
    }
}