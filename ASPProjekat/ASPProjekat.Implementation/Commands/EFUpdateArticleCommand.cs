using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFUpdateArticleCommand : IUpdateArticleCommand
    {
        private readonly ASPProjekatContext context;
        private readonly UpdateArticleValidator validator;
        // private readonly IMapper mapper;

        public EFUpdateArticleCommand(ASPProjekatContext context, UpdateArticleValidator validator)//, IMapper mapper
        {
            this.context = context;
            this.validator = validator;
            //this.mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Update Article Command";

        public void Execute(UpdateArticleDto request)
        {
            validator.ValidateAndThrow(request);

            // var exists = context.Articles.Any(x => x.Id == request.Id);          

            var article = context.Articles.Include(a => a.Price).FirstOrDefault(x => x.Id == request.Id);

            try
            {
                article.CategoryId = request.CategoryId;
                article.Name = request.Name;
                article.OnSale = request.OnSale;
                article.OnStock = request.OnStock;
                article.Price.NewPrice = request.NewPrice;
                article.Price.OldPrice = request.OldPrice;
                if (!(string.IsNullOrEmpty(request.Picture) || string.IsNullOrWhiteSpace(request.Picture)))
                {
                    article.Picture = request.Picture;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            context.SaveChanges();

        }
    }
}
//{
//	"name" : "Article created 4",
//	"categoryId" : 1,
//	"onSale" : false,
//	"onStock" : 102,
//	"priceObject":{
//		"oldPrice" : 32,
//		"newPrice" : 0
//	}
//}
