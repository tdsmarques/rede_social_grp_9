using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RedeSocial.Domain.Post.Repository
{
    public interface ICommentRepository
    {
        Task<IdentityResult> CreateComment(Comment comment, CancellationToken cancellationToken);
        Task<Account.Account> GetAccountByName(String name);
        Task<Post> GetPostById(Guid id);
    }
}