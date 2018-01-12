using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorHut
{
    public class Address
    {
        public Street street = new Street();
        public City city = new City();
        public State state = new State();
        public ZIP zip = new ZIP();
        [Key]
        public int ID { get; set; }
        public Street StreetAddress { get { return street; } set { street = value; } }
        public string AddressTwo { get; set; }
        public City City { get { return city; } set { city = value; } }
        public State State { get { return state; } set { state = value; } }
        public ZIP ZIP { get { return zip; } set { zip = value; } }
    }
}