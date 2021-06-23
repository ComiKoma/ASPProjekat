using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFUpdateUserCommand:IUpdateUserCommand
    {
        private readonly ASPProjekatContext context;
        private readonly UpdateUserValidator validator;
        // private readonly IMapper mapper;

        public EFUpdateUserCommand(ASPProjekatContext context, UpdateUserValidator validator)//, IMapper mapper
        {
            this.context = context;
            this.validator = validator;
            //this.mapper = mapper;
        }
        public int Id => 22;

        public string Name => "Update User Command";

        public void Execute(UpdateUserDto request)
        {
            validator.ValidateAndThrow(request);

            var user = context.Users.Find(request.Id);

            try
            {
                user.Username = request.Username;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Password = request.Password;
                user.Email = request.Email;
                user.IsAdmin = request.IsAdmin;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            context.SaveChanges();
        }
    }
}
