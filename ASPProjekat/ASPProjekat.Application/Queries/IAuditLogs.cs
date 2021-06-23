using ASPProjekat.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Queries
{
    public interface IAuditLogs : IQuery<AuditLogsSearch, PagedResponse<AuditLogsDto>>
    {
    }
}
