using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFUpdateQuantityCartCommand : IUpdateQuantityCart
    {
        private readonly ASPProjekatContext context;
        private readonly UpdateQuantityCartValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;

        public EFUpdateQuantityCartCommand(ASPProjekatContext context, UpdateQuantityCartValidator validator, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }

        public int Id => 12;

        public string Name => "Update Quantity in User's Cart";

        public void Execute(CartDto request)
        {
            if (!context.Cart.Any(x => x.UserId == actor.Id))
            {
                throw new Exception();
            }

            validator.ValidateAndThrow(request);

            var cartLine = context.Cart.FirstOrDefault(c => (c.ArticleId == request.ArticleId) && (c.UserId == actor.Id));

            cartLine.Quantity = request.Quantity;

            context.SaveChanges();
        }
    }
}
