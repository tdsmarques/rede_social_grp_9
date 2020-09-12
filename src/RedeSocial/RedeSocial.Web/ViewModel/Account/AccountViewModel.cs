using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RedeSocial.Web.ViewModel.Account
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email não esta em um formato correto")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public String Password { get; set; }
        
        public RoleViewModel Role { get; set; }
        [Required(ErrorMessage = "Campo Usuário é obrigatório")]
        public String UserName { get; set; }
    }
}