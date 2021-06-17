using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
