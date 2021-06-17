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
    public class EFGetOrder : IGetOrder
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;

        public EFGetOrder(ASPProjekatContext context, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.actor = actor;
        }
        public int Id => 16;

        public string Name => "Get Order Query";

        public ReadOrderDto Execute(int search)
        {
            var order = context.Orders.Include(x => x.User).Include(x => x.OrderLines).ThenInclude(x => x.Article).ThenInclude(x => x.Price).FirstOrDefault(x => (x.Id == search) && (x.UserId == actor.Id));
            if (order == null)
            {
                throw new Exception();
            }
            var readOrder = mapper.Map<ReadOrderDto>(order);
            return readOrder;
        }
    }
}
