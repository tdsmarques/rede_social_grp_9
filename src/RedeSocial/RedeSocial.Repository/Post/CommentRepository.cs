using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Comment> GetAllPostComments(Guid guid)
        {
            var post = GetPostById(guid);
            return post.Comments;
        }

        public Domain.Account.Account GetAccountByName(string name)
        {
            return this.Context.Accounts.FirstOrDefault(x => x.UserName == name);
        }

        public Domain.Post.Post GetPostById(Guid id)
        {
            return this.Context.Posts.FirstOrDefault(x => x.Id == id);
        }
    }
}