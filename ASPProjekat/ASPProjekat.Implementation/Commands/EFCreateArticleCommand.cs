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
    public class EFCreateArticleCommand : ICreateArticleCommand
    {
        private readonly ASPProjekatContext context;
        private readonly CreateArticleValidator validator;
        private readonly IMapper mapper;

        public EFCreateArticleCommand(ASPProjekatContext context, CreateArticleValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Create Product Command";

        public void Execute(CreateArticleDto request)
        {
            validator.ValidateAndThrow(request);

            var articleMapped = mapper.Map<Article>(request);

            context.Articles.Add(articleMapped);
            context.SaveChanges();
        }
    }
}
