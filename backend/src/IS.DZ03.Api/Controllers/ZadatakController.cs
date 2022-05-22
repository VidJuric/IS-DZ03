using IS.DZ03.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
