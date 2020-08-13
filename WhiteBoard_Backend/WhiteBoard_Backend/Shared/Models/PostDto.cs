using System;

namespace WhiteBoard_Backend.Shared.Models
{
    public class PostDto
    {
        public long Id { get; set; }
        public UserDto CreatedBy { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Likes { get; set; }
        public int NumberOfComments { get; set; }
        public PostType Type { get; set; }
        public string Content { get; set; }
    }
}