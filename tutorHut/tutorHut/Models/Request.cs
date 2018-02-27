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

        [Display(Name = "Date And Time")]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

    }
}