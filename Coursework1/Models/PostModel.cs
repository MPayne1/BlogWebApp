using System.ComponentModel.DataAnnotations;

namespace Coursework1.Models
{
    public class PostModel
    {
        [Required, MaxLength(30), MinLength(2)]
        public string Post { get; set; }

        [Required, Key]
        public int PostId { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
