using System.Collections.Generic;
using WhiteBoard_Backend.Models.Entities.Posts;

namespace WhiteBoard_Backend.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set;}
        public string Alias { get; set; }
        public string Email { get; set; }
        public string FullName => FirstName + " " + LastName;
        public ICollection<VideoPost> VideoPosts { get; set;}
        public ICollection<QuotePost> QuotePosts { get; set; }
        public ICollection<ImagePost> ImagePosts { get; set; }

        public User()
        {
            VideoPosts = new List<VideoPost>();
            QuotePosts = new List<QuotePost>();
            ImagePosts = new List<ImagePost>();
        }
    }
    
}