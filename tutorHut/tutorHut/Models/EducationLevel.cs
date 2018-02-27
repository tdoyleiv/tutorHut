using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tutorHut.Models
{
    [Table("EducationLevels")]
    public class EducationLevel
    {
        [Key]
        public int EducationLevelId { get; set; }

        [Display(Name = "Level Type")]
        public string LevelType { get; set; }
    }
}