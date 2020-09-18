using System;

namespace RedeSocial.Web.ViewModel.Post
{
    public class CommentRequestViewModel
    {
        public Guid PostId { get; set; }
        public string userName { get; set; }
        public string Message { get; set; }
    }
}