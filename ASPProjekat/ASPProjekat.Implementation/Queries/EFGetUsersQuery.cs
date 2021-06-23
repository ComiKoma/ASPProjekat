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
    public class EFGetUsersQuery:IGetUsersQuery
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetUsersQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 25;

        public string Name => "Get Users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(a => a.Username.ToLower().Contains(search.Username.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(a => a.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(a => a.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Email) || !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(a => a.Email.ToLower().Contains(search.Email.ToLower()));
            }

            //if (search.Email != null)
            //{
            //    query = query.Where(a => a.Email == search.Email);
            //}

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<UserDto>>(items);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = itemsMapped
            };

            return response;
        }
    }
}
