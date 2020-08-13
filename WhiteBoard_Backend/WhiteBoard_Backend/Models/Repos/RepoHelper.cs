

namespace WhiteBoard_Backend.Models.Repos
{
    public class RepoHelper
    {
        private WhiteBoardContext _context;

        public RepoHelper(WhiteBoardContext context)
        {
            _context = context;
        }

//        public async Task<Object> FindPostFromTypeAndId(PostType type, long id)
//        {
//            Object post = null;
//
//            switch (type)
//            {
//                case PostType.ImagePost:
//                    post = await _context.ImagePosts.FindAsync(id);
//                    break;
//                case PostType.QuotePost:
//                    post = await _context.QuotePosts.FindAsync(id);
//                    break;
//                case PostType.VideoPost:
//                    post = await _context.VideoPosts.FindAsync(id);
//                    break;
//            }
//            return post;
//        }
//
//        public Comment CreateConcreteCommentFromDto(CommentCreateDto dto)
//        {
//            switch (dto.Type)
//            {
//                case PostType.ImagePost:
//                    var imgComment = new ImageComment()
//                    {
//                        ImageId = dto.PostId,
//                    };
//                    return imgComment;
//                case PostType.QuotePost:
//                    var qComment = new QuoteComment()
//                    {
//                        QuoteId = dto.PostId
//                    };
//                    return qComment;
//                case PostType.VideoPost:
//                    var vComment = new VideoComment()
//                    {
//                        VideoId = dto.PostId
//                    };
//                    return vComment;  
//                default:
//                    return null;
//            }
//            
//        }

        

        
    }
}