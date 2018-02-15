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
            var userId = User.Identity.GetUserId();
            var address = Helper.LogicConversionOne((db.Addresses.Where(m => m.UserId == userId).Include(m => m.StreetAddress)).ToString());
            var city = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.City)).ToString());
            var state = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.State)).ToString());
            var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + API.GoogleAPIKey);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "6a0bce15-4b27-4816-9013-7a333847d6fc");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
            var responseData = JsonConvert.DeserializeObject<GoogleMapsGeocoderAPI>(response.Content);
            var lat = responseData.Results[0].Geometry.Location.Lat;
            var lng = responseData.Results[0].Geometry.Location.Lng;
            var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + API.GoogleAPIKey);
            var placeRequest = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "b85a13c4-39e4-3016-dfbc-bcc7fb86ce33");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse placeResponse = client.Execute(placeRequest);
            var placeResponseData = JsonConvert.DeserializeObject<GoogleMapsPlaceAPI>(placeResponse.Content);
            return View(placeResponseData);
        }
    }
}