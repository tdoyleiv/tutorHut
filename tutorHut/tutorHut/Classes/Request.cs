using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorHut.Classes
{
    public class Request
    {
        private Subject subject = new Subject();
        private Address location = new Address();
        [Key]
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public Subject Subject { get { return subject; } set { subject = value; } }
        public Address Location { get { return location; } set { location = value; } }
        public bool Status { get; set; }
    }
}