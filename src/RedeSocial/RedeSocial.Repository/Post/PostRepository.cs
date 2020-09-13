using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Post.Repository;
using RedeSocial.Repository.Context;

namespace RedeSocial.Repository.Post
{
    public class PostRepository : IPostRepository
    {
        private RedeSocialContext Context { get; set; }

        public PostRepository(RedeSocialContext context)
        {
            Context = context; 
        }

        public async Task<IdentityResult> CreatePost(Domain.Post.Post post, CancellationToken cancellationToken)
        {
            this.Context.Posts.Add(post);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public Task<Domain.Account.Account> GetAccountByName(string name)
        {
            return this.Context.Accounts.FirstOrDefaultAsync(x => x.UserName == name);
        }
    }
}