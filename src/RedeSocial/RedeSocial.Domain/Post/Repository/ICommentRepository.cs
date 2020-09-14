using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RedeSocial.Domain.Post.Repository
{
    public interface ICommentRepository
    {
        Task<IdentityResult> CreateComment(Comment comment, CancellationToken cancellationToken);
        List<Comment> GetAllPostComments(Guid guid);
        Account.Account GetAccountByName(String name);
        Post GetPostById(Guid id);
    }
}