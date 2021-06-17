using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class ReadOrderLineDto
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
