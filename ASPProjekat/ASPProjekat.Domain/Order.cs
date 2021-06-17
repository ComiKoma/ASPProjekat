using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class Order:Entity
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public enum OrderStatus
    {
        Recieved,
        Delivered,
        Shipped,
        Canceled
    }
}
