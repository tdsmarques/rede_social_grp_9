using System;
using System.Collections.Generic;
using RedeSocial.Domain.Post;

namespace RedeSocial.API.Services
{
    public interface IPostService
    {
        void Create(string userName, string message, string imageUrl, DateTime publishDateTime);
        List<Post> GetAllPosts();
    }
}