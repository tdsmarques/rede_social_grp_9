using System;
using System.Collections.Generic;

namespace RedeSocial.Domain.Post
{
    public class Post
    {
        public Guid Id { get; set; }
        public Account.Account User { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDateTime { get; set; }
        public List<Comment> Comments { get; set; }
    }
}