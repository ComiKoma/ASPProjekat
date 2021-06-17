using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Cart> OrderLines { get; set; } = new HashSet<Cart>();
        public int UserId { get; set; }
    }
}
