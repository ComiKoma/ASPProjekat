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
    public class EFGetOneUserQuery : IGetOneUserQuery
    {
        public int Id => 24;

        public string Name => "Get One User";

        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetOneUserQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public UserDto Execute(int search)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == search);
            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
