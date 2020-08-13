using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using WhiteBoard_Backend.Models;
using WhiteBoard_Backend.Models.Entities.Posts;
using WhiteBoard_Backend.Models.Repos;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Controllers
{
    [ApiController]
    [Route("/api/posts")]
    public class PostController : ControllerBase
    {
        private IImagePostRepository _imagePostRepository;
        private IVideoPostRepository _videoPostRepository;
        private IQuotePostRepository _quotePostRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;

        public PostController(IImagePostRepository imagePostRepository, IVideoPostRepository videoPostRepository, IQuotePostRepository quotePostRepository, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _imagePostRepository = imagePostRepository;
            _videoPostRepository = videoPostRepository;
            _quotePostRepository = quotePostRepository;
            _userRepository = _userRepository;
            _commentRepository = commentRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostThreadDto>>> Get(int videoCap, int imageCap, int quoteCap)
        {
            var postThreads = new List<PostThreadDto>();
            var videoPosts = await _videoPostRepository.GetPostsWithCap(videoCap);
            var imagePosts = await _imagePostRepository.GetPostsWithCap(imageCap);
            var quotePosts = await _quotePostRepository.GetPostsWithCap(quoteCap);
            
            postThreads.AddRange(videoPosts);
            postThreads.AddRange(imagePosts);
            postThreads.AddRange(quotePosts);

            if (!postThreads.Any()) return NotFound();
            return Ok(postThreads);
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PostThreadDto>> Get(long id, PostType type)
        {
            var repo = GetConcreteRepoFromType(type);
            var postThread = await repo.ReadAsync(id);

            if (postThread == null)
            {
                return NotFound();
            }

            return Ok(postThread);
        }
        
        //Deletes a post and all its comments
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id, PostType type)
        {
            var repo = GetConcreteRepoFromType(type);
            var deleteSucces = await repo.DeleteAsync(id);

            if (!deleteSucces) return NotFound();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> Post([FromBody] PostCreateDto dto)
        {
            var repo = GetConcreteRepoFromType(dto.Type);

            PostDto createDto = null;

            switch (dto)
            {
                case ImagePostCreateDto imgPostCreateDto:
                    createDto = await _imagePostRepository.CreateAsync(imgPostCreateDto);
                    break;
                case VideoPostCreateDto vidPostCreateDto:
                    createDto = await _videoPostRepository.CreateAsync(vidPostCreateDto);
                    break;
                case QuotePostCreateDto qPostCreateDto:
                    createDto = await _quotePostRepository.CreateAsync(qPostCreateDto);
                    break;
            }

            if (createDto == null)
            {
                return BadRequest();
            }

            return Ok(createDto);
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<CommentDto>> PostComment(long id, [FromBody] CommentCreateDto dto)
        {
            var commentDto = _commentRepository.CreateAsync(dto);
            if (commentDto == null) return BadRequest();
            return Ok(commentDto);
        }

        [HttpDelete("{id}/comments/{cid}")]
        public async Task<ActionResult> DeleteComment(long id, long cid)
        {
            var deleted = await _commentRepository.DeleteAsync(cid);
            if (!deleted) return NotFound();
            return Ok();
        }
        

        private IPostRepository GetConcreteRepoFromType(PostType type)
        {
            switch (type)
            {
                case PostType.ImagePost:
                    return _imagePostRepository;
                case PostType.VideoPost:
                    return _videoPostRepository;
                case PostType.QuotePost:
                    return _quotePostRepository;
                default: return null;
            }
        }
        
        
        
        
        
    }
}