using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using ASPProjekat.Application.Searches;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFGetArticlesQuery : IGetArticlesQuery
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetArticlesQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 2;

        public string Name => "Get Articles";

        public PagedResponse<ArticleDto> Execute(ArticleSearch search)
        {
            var query = context.Articles.Include(x => x.Price).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.CategoryId != null)
            {
                query = query.Where(a => a.CategoryId == search.CategoryId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<ArticleDto>>(items);

            var reponse = new PagedResponse<ArticleDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = itemsMapped
            };

            return reponse;
        }
    }
}
