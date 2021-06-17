using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using ASPProjekat.Application.Searches;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetCategoriesQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Get Categories Query";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<CategoryDto>>(items);

            var reponse = new PagedResponse<CategoryDto>
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
