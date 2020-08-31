using System;
using Microsoft.AspNetCore.Identity;

namespace RedeSocial.Domain.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime Birthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Profile Profile { get; set; }

    }
}
