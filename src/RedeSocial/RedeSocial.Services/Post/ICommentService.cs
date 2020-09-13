using System;

namespace RedeSocial.Services.Post
{
    public interface ICommentService
    {
        void Create(Guid postId, string userName, string message, DateTime publishDateTime);
    }
}