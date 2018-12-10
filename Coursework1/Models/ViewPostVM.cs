using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class ViewPostVM
    {
        [Required, MaxLength(30), MinLength(2)]
        public string Post { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        public int PostId { get; set; }

    }
}
