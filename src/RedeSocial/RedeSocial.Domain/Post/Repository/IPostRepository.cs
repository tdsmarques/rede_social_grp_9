using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RedeSocial.Domain.Post.Repository
{
    public interface IPostRepository
    {
        Task<IdentityResult> CreatePost(Post post, CancellationToken cancellationToken);
        Account.Account GetAccountByName(String name);
        List<Post> GetAllPosts();
    }
}