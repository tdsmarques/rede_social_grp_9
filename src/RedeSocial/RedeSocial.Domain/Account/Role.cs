﻿using System;
using System.Collections.Generic;

namespace RedeSocial.Domain.Account
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
