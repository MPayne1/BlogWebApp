using System.ComponentModel.DataAnnotations;

namespace Coursework1.Models
{
    public class Comment
    {
        [Required, MaxLength(256), MinLength(2)]
        public string CommentMessage { get; set; }

        [Required, ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public virtual PostModel Post { get; set; }

        
        //public virtual ApplicationUser UserId { get; set; }
    }
}