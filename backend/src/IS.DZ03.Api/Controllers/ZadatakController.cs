using IS.DZ03.Logic.Requests;
using IS.DZ03.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IS.DZ03.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZadatakController : ControllerBase
    {
        private readonly IZadatakService _zadatakService;

        public ZadatakController(IZadatakService zadatakService)
        {
            _zadatakService = zadatakService;
        }

        [HttpGet("{employeeID}")]
        public async Task<IActionResult> GetAllEmployeeTasks(long employeeID)
        {
            var result = await _zadatakService.GetEmployeeTasks(employeeID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(ZadatakRequest task)
        {
            var result = await _zadatakService.CreateTask(task);
            return Ok(result);
        }
    }
}
