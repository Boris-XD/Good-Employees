using Goodleap.Employee.Api.Business.Queries.Permissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goodleap.Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(IMediator mediator, ILogger<PermissionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPermission()
        {
            _logger.LogInformation("this isserilog test");
            _logger.LogError("this is an error on serilog");
            return Ok();
            //return Ok(await _mediator.Send(new GetAllPermissionsCommand()));
        }
    }
}
