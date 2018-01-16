using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tutorHut.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public string ProfileId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
      
        public string AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        public string SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        public string RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }


        [Display(Name = "First Name")]
        public string ProfileFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ProfileLastName { get; set; }

        [Display(Name = "Phone Number")]
        public string ProfilePhoneNumber { get; set; }

        [Display(Name = "Hourly Rate")]
        public string HourlyRate { get; set; }

        [Display(Name = "My Description")]
        public string MyDescription { get; set; }

    }
}