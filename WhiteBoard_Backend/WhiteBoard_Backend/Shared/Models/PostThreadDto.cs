using System.Collections.Generic;

namespace WhiteBoard_Backend.Shared.Models
{
    public class PostThreadDto : PostDto
    {
        public List<CommentDto> Comments { get; set; }

        public PostThreadDto()
        {
           Comments = new List<CommentDto>();
        }
    }
}