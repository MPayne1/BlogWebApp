using System.ComponentModel.DataAnnotations;

namespace Coursework1.Models
{
    public class Comment
    {
        [Required, MaxLength(256), MinLength(2), Display(Name = "Comment Message")]
        public string CommentMessage { get; set; }

        [Required, ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public virtual int PostId { get; set; }

        
        //public virtual ApplicationUser UserId { get; set; }
    }
}