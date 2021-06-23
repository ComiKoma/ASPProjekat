using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{

    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly ASPProjekatContext context;
        public UpdateUserValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.Username)
                .NotEmpty()
                .Must(x => !context.Users.Any(a => a.Username == x))
                .WithMessage("Username must be unique!");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required!");

            RuleFor(x => x.Id)
                .Must(UserExists)
                .WithMessage("User not found!");
        }

        public bool UserExists(int userId)
        {
            return context.Users.Any(c => c.Id == userId);
        }
    }
}

