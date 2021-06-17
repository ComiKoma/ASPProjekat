using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{

    public class EFCreateOrderCommand : ICreateOrderCommand
    {
        private readonly ASPProjekatContext context;
        private readonly CreateOrderValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;

        public EFCreateOrderCommand(ASPProjekatContext context, CreateOrderValidator validator, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }
        public int Id => 15;

        public string Name => "Create Order Command using EF";

        public void Execute(OrderDto request)
        {
            validator.ValidateAndThrow(request);

            var cartItemsForOrder = context.Cart.Include(x => x.Article)
                                        .ThenInclude(x => x.Price)
                                        .Where(x => x.UserId == actor.Id).ToList();

            request.OrderLines = cartItemsForOrder;
            request.UserId = actor.Id;

            foreach (var item in cartItemsForOrder)
            {
                var article = context.Articles.Find(item.ArticleId);
                var isEnough = article.OnStock - item.Quantity;
                if (isEnough > 0)
                {
                    article.OnStock -= item.Quantity;
                }
                else
                {
                    throw new Exception("Product is sold.");
                }
            }

            var order = mapper.Map<Order>(request);
            context.Orders.Add(order);
            context.Cart.RemoveRange(context.Cart.Where(x => x.UserId == actor.Id));

            context.SaveChanges();

        }
        
    }
}
