﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tutorHut
{
    public class Subject
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}