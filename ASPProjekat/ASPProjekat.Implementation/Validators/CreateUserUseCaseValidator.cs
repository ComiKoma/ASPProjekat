using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateUserUseCaseValidator : AbstractValidator<CreateUserUseCaseDto>
    {
        private readonly ASPProjekatContext context;
        public CreateUserUseCaseValidator(ASPProjekatContext context)
        {

            this.context = context;

            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(n => context.Users.Any(a => a.Id == n))
                .WithMessage("User with id of {PropertyValue} doesn't exist.");

        RuleFor(x => x.UserUseCaseId)
                .NotEmpty()
                .Must(UseCaseExists)
                .WithMessage("UseCase with id of {PropertyValue} doesn't exist.");
    }

    public bool UseCaseExists(int useCaseId)
    {
        return useCaseId > 0 && useCaseId < 21;
    }
}
}
