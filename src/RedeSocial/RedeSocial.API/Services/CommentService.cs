using System;
using System.Collections.Generic;
using System.Linq;
using RedeSocial.API.Domain;
using RedeSocial.Domain.Post;
using RedeSocial.Repository.Context;

namespace RedeSocial.API.Services
{
    public class CommentService
    {
        private readonly RedeSocialContext _redeSocialDb;

        public CommentService(RedeSocialContext context)
        {
            _redeSocialDb = context;
        }
        
        public void Create(CommentRequest commentRequest)
        {
            var user = _redeSocialDb.Accounts.FirstOrDefault(x => x.UserName == commentRequest.userName);
            var post = _redeSocialDb.Posts.FirstOrDefault(x => x.Id == Guid.Parse(commentRequest.PostId));
            var comment = new Comment();

            if (user != null) comment.UserId = user.Id;
            if (post != null) comment.PostId = post.Id;
            
            comment.Message = commentRequest.Message;
            comment.PublishDateTime = DateTime.Now;

            if (post.Comments == null)
            {
                var comments = new List<Comment>();
                comments.Add(comment);
                post.Comments = comments;
            }
            else
            {
                post.Comments.Add(comment);
            }

            _redeSocialDb.Comments.Add(comment);
            _redeSocialDb.SaveChanges();
        }
        
        public List<Comment> GetAllPostComment()
        {
            var comments =  _redeSocialDb.Comments.ToList();
            return comments;
        }
        
    }
}