using System.Collections.Generic;

namespace RedeSocial.Web.ViewModel.Post
{
    public class TimeLineViewModel
    {
        public Domain.Account.Account UserLoggedIn { get; set; }
        public List<Domain.Post.Post> Posts { get; set; } = new List<Domain.Post.Post>();
    }
}