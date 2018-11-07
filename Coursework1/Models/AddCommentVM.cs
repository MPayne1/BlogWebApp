using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class AddCommentVM
    {
        [Required, MaxLength(256), MinLength(2)]
        public string CommentMessage { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
