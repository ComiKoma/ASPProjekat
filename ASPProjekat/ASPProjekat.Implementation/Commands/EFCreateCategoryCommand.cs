using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ASPProjekatContext context;
        private readonly CreateCategoryValidator validator;
        private readonly IMapper mapper;

        public EFCreateCategoryCommand(ASPProjekatContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Create Category Command";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var catMapped = mapper.Map<Category>(request);

            context.Categories.Add(catMapped);
            context.SaveChanges();
        }
    }
}
