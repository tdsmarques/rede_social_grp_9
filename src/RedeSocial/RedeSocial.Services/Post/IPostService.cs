using System;

namespace RedeSocial.Services.Post
{
    public interface IPostService
    {
        void Create(string userName, string message, string imageUrl, DateTime publishDateTime);
    }
}