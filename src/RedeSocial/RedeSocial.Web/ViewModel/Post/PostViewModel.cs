using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Web.ViewModel.Post
{
    public class PostViewModel
    {
        public string userName { get; set; }
        
        [Required(ErrorMessage = "Campo de Texto do Post é obrigatório")]
        public string Message { get; set; }
        
        public string ImageUrl { get; set; }
    }
}