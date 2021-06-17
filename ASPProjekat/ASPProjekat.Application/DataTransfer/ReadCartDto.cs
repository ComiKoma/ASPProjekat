using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class ReadCartDto
    {
        public virtual ICollection<CartLineDto> CartLines { get; set; } = new HashSet<CartLineDto>();
        public decimal PriceSum { get; set; }
    }
}
