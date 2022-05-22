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
    public class StatusZadatkaController : ControllerBase
    {
        private IStatusZadatkaService _statusZadatkaService;

        public StatusZadatkaController(IStatusZadatkaService statusZadatkaService)
        {
            _statusZadatkaService = statusZadatkaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskStatuses()
        {
            var result = await _statusZadatkaService.GetAllTaskStatuses();
            return Ok(result);
        }
    }
}
