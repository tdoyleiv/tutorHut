using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tutorHut.Models
{
    [Table("Requests")]

    public class Request
    {
        [Key]
        public string RequestId { get; set; }

        //public string AddressId { get; set; }
        //[ForeignKey("AddressId")]
        //public Address Address { get; set; }

        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser ApplicationUser { get; set; }

        //public string SubjectId { get; set; }
        //[ForeignKey("SubjectId")]
        //public Subject Subject { get; set; }

        //public string ProfileId { get; set; }
        //[ForeignKey("ProfileId")]
        //public Profile Profile { get; set; }

        [Display(Name = "Date And Time")]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

    }
}