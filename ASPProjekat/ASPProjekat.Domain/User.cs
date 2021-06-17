using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
    }
}
