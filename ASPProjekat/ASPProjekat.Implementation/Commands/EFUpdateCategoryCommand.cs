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
    public class EFUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly ASPProjekatContext context;
        private readonly UpdateCategoryValidator validator;
        // private readonly IMapper mapper;

        public EFUpdateCategoryCommand(ASPProjekatContext context, UpdateCategoryValidator validator)//, IMapper mapper
        {
            this.context = context;
            this.validator = validator;
            //this.mapper = mapper;
        }
        public int Id => 9;

        public string Name => "Update Category Name Command";

        public void Execute(UpdateCategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var category = context.Categories.Find(request.Id);

            try
            {
                category.Name = request.Name;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            context.SaveChanges();
        }
    }
}
