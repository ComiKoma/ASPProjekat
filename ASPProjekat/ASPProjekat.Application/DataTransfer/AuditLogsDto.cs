using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class AuditLogsDto
    {
        public DateTime Date { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
    }
}
