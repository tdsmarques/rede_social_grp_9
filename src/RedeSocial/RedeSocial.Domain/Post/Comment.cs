using System;

namespace RedeSocial.Domain.Post
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId{ get; set; }
        public string UserImageUrl { get; set; }
        public string userName { get; set; }
        public string Message { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}