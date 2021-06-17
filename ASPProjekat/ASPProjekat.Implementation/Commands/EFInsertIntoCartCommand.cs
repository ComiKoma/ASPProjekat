using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFInsertIntoCartCommand : IInsertIntoCart
    {
        private readonly ASPProjekatContext context;
        private readonly InsertIntoCartValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;

        public EFInsertIntoCartCommand(ASPProjekatContext context, InsertIntoCartValidator validator, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }

        public int Id => 11;

        public string Name => "Insert Product into Cart";

        public void Execute(CartDto request)
        {
            validator.ValidateAndThrow(request);

            var cartMapped = mapper.Map<Cart>(request);
            cartMapped.UserId = actor.Id;

            context.Cart.Add(cartMapped);

            context.SaveChanges();
        }
    }
}
