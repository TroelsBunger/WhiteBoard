using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Entities.Comments
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set;} = DateTime.Now;
        public string Body { get; set;}
        
        public User User { get; set;}
        
        [ForeignKey(("User"))]
        public long UserId { get; set;}
        
        [ForeignKey(("Post"))]
        public long PostId { get; set; }
        public Post Post { get; set;}
        public PostType Type { get; set; }
    }
}