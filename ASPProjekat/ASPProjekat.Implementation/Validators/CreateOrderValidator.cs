using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        private readonly ASPProjekatContext context;
        public CreateOrderValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.OrderDate)
                .GreaterThan(DateTime.Today)
                .WithMessage("Order's date must be in future.")
                .LessThan(DateTime.Now.AddDays(30))
                .WithMessage("Order's date can't be more than 30 days from today.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address can't be empty.");
        }
    }
}
