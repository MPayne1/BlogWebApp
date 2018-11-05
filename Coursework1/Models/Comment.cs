using System.ComponentModel.DataAnnotations;

namespace Coursework1.Models
{
    public class Comment
    {
        [Required, MaxLength(256), MinLength(2)]
        public string CommentMessage { get; set; }

        //public User Commenter { get; set; }
    }
}