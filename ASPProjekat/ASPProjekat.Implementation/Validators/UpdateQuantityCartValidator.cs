using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateQuantityCartValidator : AbstractValidator<CartDto>
    {
        private readonly ASPProjekatContext context;
        public UpdateQuantityCartValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.ArticleId)
                .Must(id => context.Cart.Any(a => a.ArticleId == id))
                .WithMessage("Artical doesn't exist.");

            RuleFor(x => x.Quantity)
              .Must(q => q >= 0)
              .WithMessage("Quantity can't be negative.");
        }

    }
}
