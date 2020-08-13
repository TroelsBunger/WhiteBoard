using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WhiteBoard_Backend.Models.Entities.Comments;

namespace WhiteBoard_Backend.Models.Entities.Posts
{
    public abstract class Post
    {
        public long Id { get; set; }
        
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
    }
}