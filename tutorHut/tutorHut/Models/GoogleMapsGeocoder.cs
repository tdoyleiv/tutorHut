using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace tutorHut.Models
{
    public partial class GoogleMapsGeocoderAPI
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    //public partial class Result
    //{


    //    [JsonProperty("geometry")]
    //    public Geometry Geometry { get; set; }

    //    [JsonProperty("place_id")]
    //    public string PlaceId { get; set; }

    //    [JsonProperty("types")]
    //    public List<string> Types { get; set; }
    //}

    public partial class AddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

    //public partial class Geometry
    //{


    //    [JsonProperty("location")]
    //    public Northeast Location { get; set; }



    //    [JsonProperty("viewport")]
    //    public Bounds Viewport { get; set; }
    //}

    public partial class Bounds
    {
        [JsonProperty("northeast")]
        public Northeast Northeast { get; set; }

        [JsonProperty("southwest")]
        public Northeast Southwest { get; set; }
    }

    public partial class Northeast
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}