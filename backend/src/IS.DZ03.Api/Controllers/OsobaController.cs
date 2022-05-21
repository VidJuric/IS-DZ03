using IS.DZ03.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _osobaService.GetAllEmployees();
            return Ok(result);
        }
    }
}
