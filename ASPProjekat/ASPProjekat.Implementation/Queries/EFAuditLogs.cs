using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFAuditLogs : IAuditLogs
    {
        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFAuditLogs(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Search for Audit Logs";

        public PagedResponse<AuditLogsDto> Execute(AuditLogsSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if ((search.LogFromDate != null) && (search.LogToDate != null))
            {
                query = query.Where(x => (x.Date >= search.LogFromDate) && (x.Date <= search.LogToDate));
            }
            else if (search.LogFromDate != null)
            {
                query = query.Where(x => x.Date >= search.LogFromDate);
            }
            else if (search.LogToDate != null)
            {
                query = query.Where(x => x.Date <= search.LogToDate);
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<AuditLogsDto>>(items);

            var reponse = new PagedResponse<AuditLogsDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = itemsMapped
            };

            return reponse;
        }
    }
}
