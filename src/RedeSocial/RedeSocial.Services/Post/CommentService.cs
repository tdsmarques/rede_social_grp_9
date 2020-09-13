using RedeSocial.Domain.Post.Repository;

namespace RedeSocial.Services.Post
{
    public class CommentService : ICommentService
    {
        private ICommentRepository PostRepository { get; set; }

        public CommentService(ICommentRepository postRepository)
        {
            PostRepository = postRepository;
        }
    }
}