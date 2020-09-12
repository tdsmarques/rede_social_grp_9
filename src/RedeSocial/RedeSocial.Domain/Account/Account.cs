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
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }

        public Account()
        {
        }

        public Account(string name, DateTime birthday, string email, string password, Role role, string userName, string imageUrl)
        {
            Name = name;
            Birthday = birthday;
            Email = email;
            Password = password;
            Role = role;
            UserName = userName;
            ImageUrl = imageUrl;

        }
    }
}
