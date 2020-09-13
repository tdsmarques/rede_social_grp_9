using RedeSocial.Domain.Post.Repository;
using RedeSocial.Repository.Post;

namespace RedeSocial.Services.Post
{
    public class PostService : IPostService
    {
        private IPostRepository PostRepository { get; set; }

        public PostService(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }
    }
}