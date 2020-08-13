using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhiteBoard_Backend.Models.Entities.Comments;
using WhiteBoard_Backend.Models.Entities.Posts;

namespace WhiteBoard_Backend.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<WhiteBoardContext>();
            
            context.Database.Migrate();

            if (DbIsEmpty(context))
            {
                var user1 = new User()
                {
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    Alias = "Sam",
                    Email = "sam@ibm.com",
                    Password = "Sam123",
                };

                var user2 = new User()
                {
                    FirstName = "Bertha",
                    LastName = "Baggins",
                    Alias = "Bertha",
                    Email = "bertha@ibm.com",
                    Password = "Bertha123"
                };

                var quotePost1 = new QuotePost()
                {
                    UserId = 1,
                    //CreatedBy = user1,
                    Text = "We have a business strategy around here -  it's called getting shit done",
                    Likes = 5,

                };
                
                var quotePost2 = new QuotePost()
                {
                    UserId = 2,
                    //CreatedBy = user2,
                    Text = "If you can think it, you can build it",
                    Likes = 2
                };

                user1.QuotePosts.Add(quotePost1);
                user2.QuotePosts.Add(quotePost2);
                
                
                var imagePost = new ImagePost()
                {
                    UserId = 1,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Everest_North_Face_toward_Base_Camp_Tibet_Luca_Galuzzi_2006.jpg/560px-Everest_North_Face_toward_Base_Camp_Tibet_Luca_Galuzzi_2006.jpg"
                };

                var videoPost = new VideoPost()
                {
                    UserId = 2,
                    Url = "https://youtu.be/fFRVFHP4GLE"
                };
                
                user1.ImagePosts.Add(imagePost);
                
                user2.VideoPosts.Add(videoPost);
                
                var comment1 = new Comment()
                {
                    UserId = 1,
                    PostId = 1,
                    Body = "You are so right!"
                };
                
                imagePost.Comments.Add(comment1);
                
                var comment2 = new Comment()
                {
                    UserId = 2,
                    PostId = 2,
                    Body = "Lovely Video! So motivating :) "
                };
                
                videoPost.Comments.Add(comment2);
                
                var comment3 = new Comment()
                {
                    UserId = 2,
                    PostId = 2,
                    Body = "What a strategy!"
                };
                
                quotePost1.Comments.Add(comment3);
                
                context.Users.AddRange(
                    user1, user2
                );
                context.Posts.AddRange(videoPost, imagePost, quotePost1, quotePost2);

                context.SaveChanges();
            }
        }

        private static bool DbIsEmpty(WhiteBoardContext context)
        {
            return !context.Users.Any();
        }
    }
}