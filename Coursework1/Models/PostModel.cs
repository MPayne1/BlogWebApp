using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class PostModel
    {
        [Required, MaxLength(30), MinLength(2)]
        public string Post { get; set; }

        [Required, Key]
        public int Id { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }


        //public ApplicationUser Poster { get; set; }
        // public DateTime dateTimePosted {get ; set;}

    }
}
