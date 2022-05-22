using IS.DZ03.Logic.Requests;
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

        [HttpGet("CustomerSupport")]
        public async Task<IActionResult> GetAllCustomerSupport()
        {
            var result = await _osobaService.GetAllCustomerSupport();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(OsobaRequest employee)
        {
            var result = await _osobaService.AddEmployee(employee);
            return Ok(result);
        }
    }
}
