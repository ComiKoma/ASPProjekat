using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool OnSale { get; set; }
        public int OnStock { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual ICollection<Cart> CartLines { get; set; } = new HashSet<Cart>();
        public virtual Category Category { get; set; }
        public virtual Price Price { get; set; }
    }
}
