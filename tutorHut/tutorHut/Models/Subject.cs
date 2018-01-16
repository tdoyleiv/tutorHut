﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tutorHut.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public string SubjectID { get; set; }

        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser ApplicationUser { get; set; }

        public string EducationLevelId { get; set; }
        [ForeignKey("EducationLevelId")]
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }


    }
}