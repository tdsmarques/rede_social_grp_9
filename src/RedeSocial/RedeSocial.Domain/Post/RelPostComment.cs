using System;

namespace RedeSocial.Domain.Post
{
    public class RelPostComment
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdComment { get; set; }
    }
}