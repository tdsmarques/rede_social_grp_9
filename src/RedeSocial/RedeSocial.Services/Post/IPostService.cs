using System;
using System.Collections.Generic;

namespace RedeSocial.Services.Post
{
    public interface IPostService
    {
        void Create(string userName, string message, string imageUrl, DateTime publishDateTime);
        List<Domain.Post.Post> GetAllPosts();
    }
}