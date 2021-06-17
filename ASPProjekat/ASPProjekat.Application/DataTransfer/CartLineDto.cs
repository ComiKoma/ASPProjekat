using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class CartLineDto
    {
        public decimal Price { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }

        public string Picture { get; set; }
    }
}
