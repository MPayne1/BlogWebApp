using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class CreatePostVM
    {
        [Required, MaxLength(256), MinLength(2)]
        public string Post { get; set; }
        
        [Required, MinLength(0), MaxLength(1024)]
        public string Description { get; set; }
    }
}
