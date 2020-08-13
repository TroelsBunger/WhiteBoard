using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class ImagePostRepository : IImagePostRepository
    {
        private WhiteBoardContext _context;

        public ImagePostRepository(WhiteBoardContext context)
        {
            _context = context;
        }

        public IQueryable<ImagePost> Posts => _context.Posts.OfType<ImagePost>();
        
        public async Task<PostDto> CreateAsync(ImagePostCreateDto postCreateDto)
        {
            var imagePost = new ImagePost()
            {
               Url = postCreateDto.Content,
               UserId = postCreateDto.User.Id
            };

            await _context.Posts.AddAsync(imagePost);
            await _context.SaveChangesAsync();

            return imagePost.ToDto();
        }

        public async Task<PostThreadDto> ReadAsync(long postId)
        {
            var imagePost = (ImagePost) await _context.Posts.FindAsync(postId);

            return imagePost?.ToPostThreadDto();
        }

        public async Task<bool> DeleteAsync(long postId)
        {
            var imagePost = await _context.Posts.FindAsync(postId);
            
            if (imagePost == null) return false;

            _context.Posts.Remove(imagePost);

            await _context.SaveChangesAsync();

            return true;
        }
        
        public async Task<IEnumerable<PostThreadDto>> GetPostsWithCap(int cap)
        {
            var posts = await Posts
                .OrderByDescending(x => x.CreatedTime)
                .Take(cap)
                .ToListAsync();
            
            return posts.Select(x => x.ToPostThreadDto());

        }
    }
}