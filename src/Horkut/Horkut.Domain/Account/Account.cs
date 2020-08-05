using System;
using Microsoft.AspNetCore.Identity;

namespace Horkut.Domain.Account
{
    public class Account : IdentityUser
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime Birthday { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        
    }
}