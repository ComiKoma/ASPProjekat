using ASPProjekat.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Queries
{
    public interface IGetOrder : IQuery<int, ReadOrderDto>
    {
    }
}
