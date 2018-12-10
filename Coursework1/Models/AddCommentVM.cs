using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class AddCommentVM
    {
        [Required, MaxLength(256), MinLength(2), Display(Name = "Comment Message")]
        public string CommentMessage { get; set; }

        [Required]
        public int postId { get; set; }


    }
}
