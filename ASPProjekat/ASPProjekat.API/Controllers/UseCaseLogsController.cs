using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekat.Application;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekat.ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseLogsController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public UseCaseLogsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/UseCaseLogs
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogsSearch search, [FromServices] IAuditLogs query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

    }
}
