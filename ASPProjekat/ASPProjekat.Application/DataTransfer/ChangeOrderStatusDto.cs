using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class ChangeOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
