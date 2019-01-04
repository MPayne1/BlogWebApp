using System.ComponentModel.DataAnnotations;

namespace Coursework1.Models
{
    public class Comment
    {
        [Required, MaxLength(256), MinLength(2), Display(Name = "Comment Message")]
        public string CommentMessage { get; set; }

        [Required, Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}