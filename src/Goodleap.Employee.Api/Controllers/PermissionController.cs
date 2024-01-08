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

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPermission()
        {
            return Ok(await _mediator.Send(new GetAllPermissionsCommand()));
        }
    }
}
