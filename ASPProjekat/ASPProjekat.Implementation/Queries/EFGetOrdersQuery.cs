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
    public class EFGetOrdersQuery : IGetOrdersQuery
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetOrdersQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 26;

        public string Name => "Get Orders";

        public PagedResponse<ReadOrderDto> Execute(OrderSearch search)
        {
            var query = context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search.Address) || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(a => a.Address.ToLower().Contains(search.Address.ToLower()));
            }


            if (!string.IsNullOrEmpty(search.OrderStatus) || !string.IsNullOrWhiteSpace(search.OrderStatus))
            {
                query = query.Where(a => a.OrderStatus.Equals(search.OrderStatus));
            }

            if (search.OrderDate != null && search.OrderDate > DateTime.MinValue)
            {
                query = query.Where(a => a.OrderDate.CompareTo(search.OrderDate) == 0);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<ReadOrderDto>>(items);

            var reponse = new PagedResponse<ReadOrderDto>
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
