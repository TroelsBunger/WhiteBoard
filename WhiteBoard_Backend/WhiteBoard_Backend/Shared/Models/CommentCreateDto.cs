using System.ComponentModel.DataAnnotations;

namespace WhiteBoard_Backend.Shared.Models
{
    public class CommentCreateDto
    {
        [Required]
        public long PostId { get; set; }
        
        [Required]
        public PostType Type { get; set; }
        
        [Required]
        public long UserId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
    }
}