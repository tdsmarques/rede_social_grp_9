using System;
using System.Collections.Generic;
using RedeSocial.Domain.Post;

namespace RedeSocial.Services.Post
{
    public interface ICommentService
    {
        void Create(Guid postId, string userName, string message, DateTime publishDateTime);
        List<Comment> GetAllPostComments(Guid guid);
    }
}