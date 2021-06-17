using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Application.Queries;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFGetOneArticleQuery : IGetOneArticleQuery
    {
        public int Id => 3;

        public string Name => "Get One Article";

        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetOneArticleQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ArticleDto Execute(int search)
        {
            var article = context.Articles.Include(a => a.Price).FirstOrDefault(x => x.Id == search);
            if (article == null)
            {
                throw new EntityNotFoundException(search, typeof(Article));
            }
            var articleDto = mapper.Map<ArticleDto>(article);
            return articleDto;
        }
    }
}
