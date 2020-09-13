using System;
using System.Threading;
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

        public void Create(string userName, string message, string imageUrl, DateTime publishDateTime)
        {
            var user = PostRepository.GetAccountByName(userName);
            var post = new Domain.Post.Post();

            post.User = user;
            post.Message = message;
            if (string.IsNullOrEmpty(imageUrl))
            {
                post.ImageUrl = null;
            }
            else
            {
                post.ImageUrl = imageUrl;
            }
            post.PublishDateTime = publishDateTime;

            PostRepository.CreatePost(post, CancellationToken.None);

        }
    }
}