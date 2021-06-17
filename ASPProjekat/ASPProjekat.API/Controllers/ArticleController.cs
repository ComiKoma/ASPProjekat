using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Queries;
using ASPProjekat.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekat.ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ArticleController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Article
        [HttpGet]
        public IActionResult Get([FromQuery] ArticleSearch search, [FromServices] IGetArticlesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, [FromServices] IGetOneArticleQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Article
        [HttpPost]
        public IActionResult Post([FromForm] CreateArticleDto dto, [FromServices] ICreateArticleCommand command)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.ImageObj.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.ImageObj.CopyTo(fileStream);
            }
            dto.Picture = newFileName;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateArticleDto dto, [FromServices] IUpdateArticleCommand command)
        {
            if (dto.ImageObj != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.ImageObj.FileName);

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.ImageObj.CopyTo(fileStream);
                }

                dto.Picture = newFileName;
            }

            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteArticleCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
