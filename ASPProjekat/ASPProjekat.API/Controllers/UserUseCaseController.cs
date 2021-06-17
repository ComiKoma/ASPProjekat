using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserUseCaseController : ControllerBase
    {

        private readonly UseCaseExecutor executor;

        public UserUseCaseController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST api/<UserUseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserUseCaseDto dto, [FromServices] ICreateUserUseCase command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<UserUseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserUseCase command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
