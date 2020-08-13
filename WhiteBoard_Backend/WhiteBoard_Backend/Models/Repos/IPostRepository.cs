using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public interface IPostRepository
    {
        Task<PostThreadDto> ReadAsync(long postId);
        Task<bool> DeleteAsync(long postId);
        Task<IEnumerable<PostThreadDto>> GetPostsWithCap(int cap);
    }

    public interface IImagePostRepository : IPostRepository
    {
        Task<PostDto> CreateAsync(ImagePostCreateDto postCreateDto);
        IQueryable<ImagePost> Posts { get; }
    }

    public interface IVideoPostRepository : IPostRepository
    {
        Task<PostDto> CreateAsync(VideoPostCreateDto postCreateDto);
        IQueryable<VideoPost> Posts { get; }
    }

    public interface IQuotePostRepository : IPostRepository
    {
        Task<PostDto> CreateAsync(QuotePostCreateDto postCreateDto);
        IQueryable<QuotePost> Posts { get; }
    }
}