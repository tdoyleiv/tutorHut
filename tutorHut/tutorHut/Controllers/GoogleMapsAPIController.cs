using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using tutorHut.Models;
using Newtonsoft.Json;
using RestSharp;
using tutorHut.Classes;

namespace tutorHut.Controllers
{
    public class GoogleMapsAPIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: GoogleMapsAPI
        public ActionResult Index()
        {
            
            return View();
        }

    }
}