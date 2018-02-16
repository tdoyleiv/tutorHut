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
            //var userId = User.Identity.GetUserId();
            //var address = Helper.LogicConversionOne((db.Addresses.Where(m => m.UserId == userId).Include(m => m.StreetAddress)).ToString());
            //var city = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.City)).ToString());
            //var state = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.State)).ToString());
            //var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + API.GoogleAPIKey);
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Postman-Token", "6a0bce15-4b27-4816-9013-7a333847d6fc");
            //request.AddHeader("Cache-Control", "no-cache");
            //IRestResponse response = client.Execute(request);
            //var responseData = JsonConvert.DeserializeObject<GoogleMapsGeocoderAPI>(response.Content);

            //var lat = responseData.Results[0].Geometry.Location.Lat;
            //var lng = responseData.Results[0].Geometry.Location.Lng;
            //var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + API.GoogleAPIKey);
            //var placeRequest = new RestRequest(Method.GET);
            //request.AddHeader("Postman-Token", "b85a13c4-39e4-3016-dfbc-bcc7fb86ce33");
            //request.AddHeader("Cache-Control", "no-cache");
            //IRestResponse placeResponse = client.Execute(placeRequest);
            //var placeResponseData = Jso+nConvert.DeserializeObject<GoogleMapsPlaceAPI>(placeResponse.Content);
            //return View(placeResponseData);



            //return View();



            //this is a string
            //var userId = User.Identity.GetUserId();

            //this is what i want
            //Profile loginProfile = db.Profiles.Include(d => d.Address).Where(n => n.UserId == userId).First();


            //var address = Helper.LogicConversionOne((db.Addresses.Where(m => m.UserId == userId).Include(m => m.StreetAddress)).ToString());


            //var city = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.City)).ToString());
            //var state = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.State)).ToString());


            //var address = loginProfile.Address.StreetAddress;
            //var city = loginProfile.Address.City;
            //var state = loginProfile.Address.State;


            string address = "137+vermont+ave";
            string city = "+Fort+Myers";
            string state = "+Florida";




            //string addressMagic = "137 vermont ave";
            //var address = Helper.LogicConversionOne(addressMagic);


            //var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + API.GoogleAPIKey);

            var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + "&key=AIzaSyC4HZBFwtooq_F6z1cy8g7K9vAoVLP2qWE");
            


            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "6a0bce15-4b27-4816-9013-7a333847d6fc");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
            var responseData = JsonConvert.DeserializeObject<GoogleMapsPlaceAPI>(response.Content);

            var lat = responseData.Results[0].Geometry.Location.Lat;
            var lng = responseData.Results[0].Geometry.Location.Lng;

            //var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + API.GoogleAPIKey);

            var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + "&key=AIzaSyC4HZBFwtooq_F6z1cy8g7K9vAoVLP2qWE");



            var placeRequest = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "b85a13c4-39e4-3016-dfbc-bcc7fb86ce33");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse placeResponse = client.Execute(placeRequest);
            var placeResponseData = JsonConvert.DeserializeObject<GoogleMapsPlaceAPI>(placeResponse.Content);






            return View(placeResponseData);
        }


        //POST
        //[HttpPost]
        //public ActionResult Index(string inputAddress, string inputCity, string inputState)
        //{


        //    //var userId = User.Identity.GetUserId();
        //    //var address = Helper.LogicConversionOne((db.Addresses.Where(m => m.UserId == userId).Include(m => m.StreetAddress)).ToString());
        //    //var city = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.City)).ToString());
        //    //var state = Helper.LogicConversionTwo((db.Addresses.Where(m => m.UserId == userId).Include(m => m.State)).ToString());

        //    var address = inputAddress;
        //    var city = inputCity;
        //    var state = inputState;

        //    var client = new RestClient("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "," + city + "," + state + API.GoogleAPIKey);

        //    //var request = new RestRequest(Method.GET);
        //    var request = new RestRequest(Method.POST);

        //    request.AddHeader("Postman-Token", "6a0bce15-4b27-4816-9013-7a333847d6fc");
        //    request.AddHeader("Cache-Control", "no-cache");
        //    IRestResponse response = client.Execute(request);
        //    var responseData = JsonConvert.DeserializeObject<GoogleMapsGeocoderAPI>(response.Content);

        //    var lat = responseData.Results[0].Geometry.Location.Lat;
        //    var lng = responseData.Results[0].Geometry.Location.Lng;
        //    var placeClient = new RestClient("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=4000&type=school,library" + API.GoogleAPIKey);
        //    var placeRequest = new RestRequest(Method.GET);
        //    request.AddHeader("Postman-Token", "b85a13c4-39e4-3016-dfbc-bcc7fb86ce33");
        //    request.AddHeader("Cache-Control", "no-cache");
        //    IRestResponse placeResponse = client.Execute(placeRequest);
        //    var placeResponseData = JsonConvert.DeserializeObject<GoogleMapsPlaceAPI>(placeResponse.Content);
        //    return View(placeResponseData);


        //    //return View();
        //}


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



    }
}