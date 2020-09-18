using System.Collections.Generic;

namespace RedeSocial.Web.ViewModel.Post
{
    public class CommentViewModel
    {
        public Domain.Account.Account UserLoggedIn { get; set; }
        public Domain.Post.Post Post { get; set; }
        public Domain.Post.Comment newComment { get; set; }
        public List<Domain.Post.Comment> Comments { get; set; }
    }
}