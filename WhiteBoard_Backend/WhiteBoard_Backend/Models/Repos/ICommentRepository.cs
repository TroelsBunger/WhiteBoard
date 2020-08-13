using System.Threading.Tasks;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public interface ICommentRepository
    {
        Task<CommentDto> CreateAsync(CommentCreateDto dto);
        Task<bool> DeleteAsync(long commentId);
    }
}