using ASPProjekat.Application.DataTransfer;
using ASPProjekat.EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticleDto>
    {
        private readonly ASPProjekatContext context;
        public CreateArticleValidator(ASPProjekatContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(n => !context.Articles.Any(a => a.Name == n))
                .WithMessage("Article Name must be unique!");

            RuleFor(x => x.CategoryId)
                .Must(CategoryExists)
                .WithMessage("Category with id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.OldPrice)
                .Must(x => x > 0)
                .WithMessage("Old price is regular product price and can't be negative or 0.");

            RuleFor(x => x.NewPrice)
                .Must(x => x >= 0)
                .WithMessage("New price can't be a negative number.");


            RuleFor(x => x.OnStock)
                .Must(x => x > 0)
                .WithMessage("On stock cant'be negative.");

            RuleFor(x => x.Picture)
                .NotEmpty()
                .WithMessage("Picture is required!");
        }

        public bool CategoryExists(int categoryId)
        {
            return context.Categories.Any(c => c.Id == categoryId);
        }

    }
}
