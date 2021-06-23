using ASPProjekat.Application.Commands;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ASPProjekatContext context;

        public EFDeleteUserCommand(ASPProjekatContext context)
        {
            this.context = context;
        }
        public int Id => 23;

        public string Name => "Delete User Command";

        public void Execute(int request)
        {
            var user = context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
