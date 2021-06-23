using ASPProjekat.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Searches
{
    public class OrderSearch : PagedSearch
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }

    }
}
