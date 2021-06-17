using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFChangeOrderStatusCommand : IChangeOrderStatus
    {
        private readonly ASPProjekatContext context;

        public EFChangeOrderStatusCommand(ASPProjekatContext context)
        {
            this.context = context;
        }

        public int Id => 17;

        public string Name => "Change Order Status";

        public void Execute(ChangeOrderStatusDto request)
        {
            var order = context.Orders.Find(request.OrderId);
            if (order == null)
            {
                throw new EntityNotFoundException(request.OrderId, typeof(Order));
            }

            order.OrderStatus = request.OrderStatus;
            context.SaveChanges();
        }
    }
}
