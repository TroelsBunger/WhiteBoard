using System;

namespace WhiteBoard_Backend.Shared.Models
{
    public class CommentDto
    {
        public UserDto Creator { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public long Id { get; set; }
    }
}