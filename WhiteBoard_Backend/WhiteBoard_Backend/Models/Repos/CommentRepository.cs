using System.Threading.Tasks;
using WhiteBoard_Backend.Models.Entities.Comments;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private WhiteBoardContext _context;
        private RepoHelper _repoHelper;

        public CommentRepository(WhiteBoardContext context)
        {
            _context = context;
            _repoHelper = new RepoHelper(_context);
        }
        
        public async Task<CommentDto> CreateAsync(CommentCreateDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            var post = await _context.Posts.FindAsync(dto.PostId);
            
            if (user == null || post == null)
            {
                return null;
            }

            var comment = new Comment()
            {
                Body = dto.Content,
                Type = dto.Type,
                PostId = dto.PostId,
                UserId = user.Id
            };

            _context.Comments.Add(comment);
            
            await _context.SaveChangesAsync();

            return comment.ToDto();

        }

        public async Task<bool> DeleteAsync(long commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment == null) return false;

            _context.Comments.Remove(comment);
            
            await _context.SaveChangesAsync();

            return true;

        }
        
        
    }
}