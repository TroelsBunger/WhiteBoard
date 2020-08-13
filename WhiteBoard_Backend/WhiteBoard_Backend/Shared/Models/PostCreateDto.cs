using System.ComponentModel.DataAnnotations;

namespace WhiteBoard_Backend.Shared.Models
{
    public class PostCreateDto
    {
        [Required]
        public UserDto User { get; set;}
        [Required]
        public string Content { get; set; }
        [Required]
        public PostType Type { get; set; }
    }
}