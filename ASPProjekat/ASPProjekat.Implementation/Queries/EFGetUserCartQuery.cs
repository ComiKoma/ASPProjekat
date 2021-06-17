using ASPProjekat.Application;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFGetUserCartQuery : IGetUserCart
    {
        private readonly ASPProjekatContext context;
        private readonly IApplicationActor actor;
        private readonly IMapper mapper;

        public EFGetUserCartQuery(ASPProjekatContext context, IApplicationActor actor, IMapper mapper)
        {
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Get User Cart Query";

        public ReadCartDto Execute(int search)
        {
            if (actor.Id == search)
            {
                var cart = context.Cart.Include(c => c.Article).ThenInclude(a => a.Price).Where(x => x.UserId == search).ToList();
                var cartLinesMapped = mapper.Map<ICollection<CartLineDto>>(cart);
                var readCart = new ReadCartDto
                {
                    CartLines = cartLinesMapped,
                    PriceSum = cartLinesMapped.Sum(x => x.Price)
                };
                return readCart;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

        }
    }
}
