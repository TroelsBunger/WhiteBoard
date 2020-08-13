using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class QuotePostRepository : IQuotePostRepository
    {
        private WhiteBoardContext _context;

        public QuotePostRepository(WhiteBoardContext context)
        {
            _context = context;
        }

        public IQueryable<QuotePost> Posts => _context.Posts.OfType<QuotePost>();
        
        public async Task<PostDto> CreateAsync(QuotePostCreateDto postCreateDto)
        {
            var quotePost = new QuotePost()
            {
                Text = postCreateDto.Content,
                UserId = postCreateDto.User.Id
            };

            await _context.Posts.AddAsync(quotePost);
            await _context.SaveChangesAsync();
            return quotePost.ToDto();

        }

        public async Task<PostThreadDto> ReadAsync(long postId)
        {
            var quotePost = (QuotePost) await _context.Posts.FindAsync(postId);

            return quotePost?.ToPostThreadDto();
        }

        public async Task<bool> DeleteAsync(long postId)
        {
            var quotePost = await _context.Posts.FindAsync(postId);
            
            if (quotePost == null) return false;

            _context.Posts.Remove(quotePost);

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