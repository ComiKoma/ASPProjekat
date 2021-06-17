using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Domain
{
    public class Price
    {
        public int Id { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
