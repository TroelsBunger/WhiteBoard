using System.Collections.Generic;
using System.Linq;
using WhiteBoard_Backend.Models.Entities.Comments;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models
{
    public static class EntityConverter
    {

        public static PostDto ToDto(this ImagePost imgPost)
        {
            var returnDto = new PostDto()
            {
                Id = imgPost.Id,
                CreatedBy = imgPost.User.ToDto(),
                UserId = imgPost.Id,
                CreatedTime = imgPost.CreatedTime,
                Likes = imgPost.Likes, 
                Content = imgPost.Url,
                Type = PostType.ImagePost,
                NumberOfComments = imgPost.Comments.Count,
            };

            return returnDto;
        }
        
        public static PostDto ToDto(this VideoPost vidPost)
        {
            var returnDto = new PostDto()
            {
                Id = vidPost.Id,
                CreatedBy = vidPost.User.ToDto(),
                UserId = vidPost.Id,
                CreatedTime = vidPost.CreatedTime,
                Likes = vidPost.Likes, 
                Content = vidPost.Url,
                Type = PostType.ImagePost,
                NumberOfComments = vidPost.Comments.Count,
            };

            return returnDto;
        }
        
        public static PostDto ToDto(this QuotePost qPost)
        {
            var returnDto = new PostDto()
            {
                Id = qPost.Id,
                CreatedBy = qPost.User.ToDto(),
                UserId = qPost.Id,
                CreatedTime = qPost.CreatedTime,
                Likes = qPost.Likes, 
                Content = qPost.Text,
                Type = PostType.ImagePost,
                NumberOfComments = qPost.Comments.Count,
            };

            return returnDto;
        }
        
        private static PostDto ConvertToPostDto(Post post)
        {
            return new PostDto()
            {
                Id = post.Id,
                CreatedBy = post.User.ToDto(),
                UserId = post.Id,
                CreatedTime = post.CreatedTime,
                Likes = post.Likes,
            };
        }
        
        public static UserDto ToDto(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Alias = user.Alias,
                Email = user.Email,
                Id = user.Id,
            };
        }

        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto()
            {
                Creator = comment.User.ToDto(),
                CreatedTime = comment.CreateTime,
                Content = comment.Body,
                Id = comment.Id
            };
        }

        public static PostThreadDto ToPostThreadDto(this ImagePost imagePost)
        {
            var threadDto = new PostThreadDto()
            {
                Id = imagePost.Id,
                CreatedBy = imagePost.User.ToDto(),
                UserId = imagePost.Id,
                CreatedTime = imagePost.CreatedTime,
                Likes = imagePost.Likes,
                Comments = imagePost.Comments.ToDto().ToList(),
                Content = imagePost.Url,
                NumberOfComments = imagePost.Comments.Count,
                Type = PostType.QuotePost,
            };

            return threadDto;
        }
        
        public static PostThreadDto ToPostThreadDto(this VideoPost videoPost)
        {
            var threadDto = new PostThreadDto()
            {
                Id = videoPost.Id,
                CreatedBy = videoPost.User.ToDto(),
                UserId = videoPost.Id,
                CreatedTime = videoPost.CreatedTime,
                Likes = videoPost.Likes,
                Comments = videoPost.Comments.ToDto().ToList(),
                Content = videoPost.Url,
                NumberOfComments = videoPost.Comments.Count,
                Type = PostType.QuotePost,
            };

            return threadDto;
        }
        
        public static PostThreadDto ToPostThreadDto(this QuotePost qPost)
        {
            var threadDto = new PostThreadDto()
            {
                Id = qPost.Id,
                CreatedBy = qPost.User.ToDto(),
                UserId = qPost.Id,
                CreatedTime = qPost.CreatedTime,
                Likes = qPost.Likes,
                Comments = qPost.Comments.ToDto().ToList(),
                Content = qPost.Text,
                NumberOfComments = qPost.Comments.Count,
                Type = PostType.QuotePost,
            };
           

            return threadDto;
        }

        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
            {
                yield return comment.ToDto();
            }
        }

        private static PostThreadDto ConvertToPostThreadDto(Post post)
        {

            return new PostThreadDto()
            {
                Id = post.Id,
                CreatedBy = post.User.ToDto(),
                UserId = post.Id,
                CreatedTime = post.CreatedTime,
                Likes = post.Likes,
            };
        }
    }
}