using System;

namespace RedeSocial.Domain.Post
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public Account.Account User { get; set; }
        public string Message { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}