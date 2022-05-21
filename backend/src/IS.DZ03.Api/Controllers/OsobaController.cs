using IS.DZ03.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System.Threading.Tasks;

namespace IS.DZ03.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OsobaController : ControllerBase
    {
        private readonly IOsobaService _osobaService;

        public OsobaController(IOsobaService osobaService)
        {
            _osobaService = osobaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] SieveModel model)
        {
            var result = await _osobaService.GetAllEmployees(model);
            return Ok(result);
        }
    }
}
