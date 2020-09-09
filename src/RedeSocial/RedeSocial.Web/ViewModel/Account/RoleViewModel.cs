using System;
using System.Collections.Generic;

namespace RedeSocial.Web.ViewModel.Account
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
    }
}