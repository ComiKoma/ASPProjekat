using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int? ArticleId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Article Article { get; set; }
    }
}
