using ASPProjekat.Application;
using ASPProjekat.EFDataAccess;
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
    public class FakerController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromServices] IFakerData faker)
        {
            faker.AddUsers();
            faker.AddCategories();
            faker.AddArticles();
            faker.AddPrices();
            faker.AddOrders();
            faker.AddOrderLines();
            faker.AddCart();
            faker.AddUseCases();

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
