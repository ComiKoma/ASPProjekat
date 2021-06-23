using ASPProjekat.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class AuditLogsSearch : PagedSearch
    {
        public DateTime? LogFromDate { get; set; }
        public DateTime? LogToDate { get; set; }
        public string UseCaseName { get; set; }
        public string Username { get; set; }

    }
}
