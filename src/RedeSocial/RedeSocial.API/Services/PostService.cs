using System;
using System.Collections.Generic;
using System.Linq;
using RedeSocial.API.Domain;
using RedeSocial.Domain.Post;
using RedeSocial.Repository.Context;

namespace RedeSocial.API.Services
{
    public class PostService
    {
        private readonly RedeSocialContext _redeSocialDb;

        public PostService(RedeSocialContext context)
        {
            _redeSocialDb = context;
        }

        public void Create(PostRequest postRequest)
        {
            var user = _redeSocialDb.Accounts.FirstOrDefault(x => x.UserName == postRequest.userName);
            var post = new Post();

            if (user != null)
            {
                post.AccountId = user.Id;
                post.UserImageUrl = user.ImageUrl;
                post.userName = user.Name;
            }
            post.Message = postRequest.Message;
            
            post.ImageUrl = string.IsNullOrEmpty(postRequest.ImageUrl) ? null : postRequest.ImageUrl;
            post.PublishDateTime = DateTime.Now;
            
            _redeSocialDb.Posts.Add(post);
            _redeSocialDb.SaveChanges();
        }

        public List<Post> GetAllPosts()
        {
            return _redeSocialDb.Posts.ToList();
        }
    }
}