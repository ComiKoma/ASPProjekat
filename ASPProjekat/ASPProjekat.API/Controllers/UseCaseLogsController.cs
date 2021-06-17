using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekat.Application;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekat.ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogsController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public UseCaseLogsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/UseCaseLogs
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogsSearchDto search, [FromServices] IAuditLogs query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/UseCaseLogs/5
        [HttpGet("{id}", Name = "GetLogs")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UseCaseLogs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UseCaseLogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
