using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekat.ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST: api/Register
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDto request, [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }


    }
}
