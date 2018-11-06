﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class PostModel
    {
        [Required, MaxLength(256), MinLength(2)]
        public string Post { get; set; }

        [Required, Key]
        public int Id { get; set; }


        //public virtual ApplicationUser UserId { get; set; }

    }
}
