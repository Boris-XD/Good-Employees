using Goodleap.Employee.Api.Business.Commands.EmployeePermissions;
using Goodleap.Employee.Api.Business.Queries.EmployeePermissions;
using Goodleap.Employee.Api.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goodleap.Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeePermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeePermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateEmployeePermission([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            return Ok(await _mediator.Send(new UpdatePermissionCommand(updatePermissionDto)));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployeePermission()
        {
            return Ok(await _mediator.Send(new GetAllEmployeePermissionCommand()));
        }
    }
}
