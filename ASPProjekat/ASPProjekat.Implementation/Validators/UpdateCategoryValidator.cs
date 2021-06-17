using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ASPProjekatContext context;
        public UpdateCategoryValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => !context.Categories.Any(a => a.Name == x))
                .WithMessage("Category Name must be unique!");

            RuleFor(x => x.Id)
                .Must(CategoryExists)
                .WithMessage("Category not found!");
        }

        public bool CategoryExists(int categoryId)
        {
            return context.Categories.Any(c => c.Id == categoryId);
        }
    }
}
