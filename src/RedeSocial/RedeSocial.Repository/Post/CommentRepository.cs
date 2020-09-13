using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Post;
using RedeSocial.Domain.Post.Repository;
using RedeSocial.Repository.Context;

namespace RedeSocial.Repository.Post
{
    public class CommentRepository : ICommentRepository
    {
        private bool disposedValue;
        private RedeSocialContext Context { get; set; }

        public CommentRepository(RedeSocialContext context)
        {
            Context = context;
        }

        public async Task<IdentityResult> CreateComment(Comment comment, CancellationToken cancellationToken)
        {
            this.Context.Comments.Add(comment);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public Task<Domain.Account.Account> GetAccountByName(string name)
        {
            return this.Context.Accounts.FirstOrDefaultAsync(x => x.UserName == name);
        }

        public Task<Domain.Post.Post> GetPostById(Guid id)
        {
            return this.Context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}