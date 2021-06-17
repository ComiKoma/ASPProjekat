using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
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
    public class CartController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public CartController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Cart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "GetCart")]
        public IActionResult Get(int id, [FromServices] IGetUserCart query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult Post([FromBody] CartDto dto, [FromServices] IInsertIntoCart command)
        {
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CartDto dto, [FromServices] IUpdateQuantityCart command)
        {
            dto.ArticleId = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductFromCart command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
