using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class ViewCommentVM
    {
        [Required, MaxLength(256), MinLength(2), Display(Name = "Comment Message")]
        public string CommentMessage { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
