using Microsoft.EntityFrameworkCore;
using WhiteBoard_Backend.Models.Entities.Comments;
using WhiteBoard_Backend.Models.Entities.Posts;

namespace WhiteBoard_Backend.Models
{
    public class WhiteBoardContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
       
        
        
        public WhiteBoardContext(DbContextOptions<WhiteBoardContext> options) : base(options)
        {
        }
        
      
    }
}