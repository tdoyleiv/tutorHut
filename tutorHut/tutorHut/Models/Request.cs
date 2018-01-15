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
        public int RequestId { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        [Display(Name = "Date And Time")]
        public string DateAndTime { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


    }
}