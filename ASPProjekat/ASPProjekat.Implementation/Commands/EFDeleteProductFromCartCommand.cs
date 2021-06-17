using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFDeleteProductFromCartCommand : IDeleteProductFromCart
    {
        private readonly ASPProjekatContext context;
        private readonly IApplicationActor actor;

        public EFDeleteProductFromCartCommand(ASPProjekatContext context, IApplicationActor actor)
        {
            this.context = context;
            this.actor = actor;
        }
        public int Id => 13;

        public string Name => "Delete Article from Cart";

        public void Execute(int request)
        {
            var item = context.Cart.FirstOrDefault(x => (x.UserId == actor.Id) && (x.ArticleId == request));

            if (item == null)
            {
                throw new EntityNotFoundException(request, typeof(Article));
            }

            context.Cart.Remove(item);
            context.SaveChanges();
        }
    }
}
