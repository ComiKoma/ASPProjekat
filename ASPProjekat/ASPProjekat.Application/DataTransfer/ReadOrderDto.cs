using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserIdentity { get; set; }
        public ICollection<ReadOrderLineDto> ReadOrderLines { get; set; }
        public string OrderStatus { get; set; }
    }

}
