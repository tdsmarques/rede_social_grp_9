using System;
using System.Collections.Generic;

namespace RedeSocial.Web.ViewModel.Post
{
    public class PostTimeLineViewModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string UserImageUrl { get; set; }
        public string userName { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDateTime { get; set; }
        public List<Domain.Post.Comment> Comments { get; set; }
    }
}