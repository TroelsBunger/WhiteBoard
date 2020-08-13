using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class VideoPostRepository : IVideoPostRepository
    {
        private WhiteBoardContext _context;

        public VideoPostRepository(WhiteBoardContext context)
        {
            _context = context;
        }

        public IQueryable<VideoPost> Posts => _context.Posts.OfType<VideoPost>();
        
        public async Task<PostDto> CreateAsync(VideoPostCreateDto postCreateDto)
        {
            var videoPost = new VideoPost()
            {
                Url = postCreateDto.Content,
                UserId = postCreateDto.User.Id,
            };

            await _context.Posts.AddAsync(videoPost);
            await _context.SaveChangesAsync();
            return videoPost.ToDto();

        }

        public async Task<PostThreadDto> ReadAsync(long postId)
        {
            var videoPost = await _context.Posts.FindAsync(postId);
            
            if (videoPost == null) return null;

            return videoPost.ToPostThreadDto();
        }

        public async Task<bool> DeleteAsync(long postId)
        {
            var videoPost = await _context.Posts.FindAsync(postId);
            
            if (videoPost == null) return false;

            _context.Posts.Remove(videoPost);

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