using System;

namespace RedeSocial.API.Domain
{
    public class CommentRequest
    {
        public Guid PostId { get; set; }
        public string userName { get; set; }
        public string Message { get; set; }
    }
}