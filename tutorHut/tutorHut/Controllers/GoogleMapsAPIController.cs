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
<<<<<<< HEAD
            var userId = User.Identity.GetUserId();
            var address = LogicConversionOne((db.Addresses.Where(m => m.UserId == userId).Include(m => m.StreetAddress)).ToString());
            var city = LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.City)).ToString());
            var state = LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.State)).ToString());
            var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + "&key=AIzaSyC4HZBFwtooq_F6z1cy8g7K9vAoVLP2qWE");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "6a0bce15-4b27-4816-9013-7a333847d6fc");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
            var responseData = JsonConvert.DeserializeObject<GoogleMapsGeocoderAPI>(response.Content);
            var lat = responseData.Results[0].Geometry.Location.Lat;
            var lng = responseData.Results[0].Geometry.Location.Lng;
            var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + "&key=AIzaSyC4HZBFwtooq_F6z1cy8g7K9vAoVLP2qWE");
            var placeRequest = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "b85a13c4-39e4-3016-dfbc-bcc7fb86ce33");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse placeResponse = client.Execute(placeRequest);
            var placeResponseData = JsonConvert.DeserializeObject<GoogleMapsPlaceAPI>(placeResponse.Content);
            return View(placeResponseData);
        }
        public string LogicConversionOne(string parameter)
        {
            var array = parameter.ToString().Split(null);
            for (int i = 1; i < array.Length; i++)
            {
                var result = "+" + array[i];
            }
            return array.ToString();
        }
        public string LogicConversionTwo(string parameter)
        {
            var array = parameter.ToString().Split(null);
            for (int i = 0; i < array.Length; i++)
            {
                var result = "+" + array[i];
            }
            return array.ToString();
        }
=======
            
            return View();
        }

        // POST 
        //public ActionResult Index(string blank)
        //{
        //    return View();
        //}





>>>>>>> f0d63c99ff08f13aa817c2cdf56be49d1a4f8ca7
    }
}