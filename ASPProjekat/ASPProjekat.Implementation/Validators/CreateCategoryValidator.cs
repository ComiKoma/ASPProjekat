using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly ASPProjekatContext context;
        public CreateCategoryValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => !context.Categories.Any(a => a.Name == x))
                .WithMessage("Category Name must be unique!");
        }
    }
}
