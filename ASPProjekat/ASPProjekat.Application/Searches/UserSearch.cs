﻿using ASPProjekat.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Searches
{
    public class UserSearch: PagedSearch
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
