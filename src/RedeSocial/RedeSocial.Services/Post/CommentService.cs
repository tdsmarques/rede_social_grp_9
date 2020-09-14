using System;
using System.Collections.Generic;
using System.Threading;
using RedeSocial.Domain.Post;
using RedeSocial.Domain.Post.Repository;

namespace RedeSocial.Services.Post
{
    public class CommentService : ICommentService
    {
        private ICommentRepository CommentRepository { get; set; }

        public CommentService(ICommentRepository postRepository)
        {
            CommentRepository = postRepository;
        }

        public void Create(Guid postId, string userName, string message, DateTime publishDateTime)
        {
            var post = CommentRepository.GetPostById(postId);
            var user = CommentRepository.GetAccountByName(userName);

            var comment = new Domain.Post.Comment();

            comment.PostId = post.Id;
            comment.UserId = user.Id;
            comment.Message = message;
            comment.PublishDateTime = publishDateTime;

            CommentRepository.CreateComment(comment, CancellationToken.None);

        }

        public List<Comment> GetAllPostComments(Guid guid)
        {
            return CommentRepository.GetAllPostComments(guid);
        }
    }
}