using IS.DZ03.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IS.DZ03.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UslugaController : ControllerBase
    {
        private IUslugaService _uslugaService;

        public UslugaController(IUslugaService uslugaService)
        {
            _uslugaService = uslugaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var result = await _uslugaService.GetAllServices();
            return Ok(result);
        }
    }
}
