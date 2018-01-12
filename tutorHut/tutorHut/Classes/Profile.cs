using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorHut
{
    public class Profile
    {
        //Need role assignment
        private Address address = new Address();
        private bool isAdult;
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get { return address; } set { address = value; } }
        public bool IsAdult { get { return isAdult; } set { isAdult = value; } }
        public bool VerifyAdult(string token)
        {
            if (token == "adult")
            {
                isAdult = true;
            }
            else if (token == "minor")
            {
                isAdult = false;
            }
            return isAdult;
        }
    }
}