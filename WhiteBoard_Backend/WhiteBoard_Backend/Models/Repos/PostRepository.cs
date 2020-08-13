using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class PostRepository : IPostRepository
    {
        private WhiteBoardContext _context;

        public PostRepository(WhiteBoardContext context)
        {
            _context = context;
        }
        public async Task<PostThreadDto> ReadAsync(long postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null) return null;

            return post.ToPostThreadDto();

        }

        public Task<bool> DeleteAsync(long postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PostThreadDto>> GetPostsWithCap(int cap)
        {
            throw new System.NotImplementedException();
        }
    }
}