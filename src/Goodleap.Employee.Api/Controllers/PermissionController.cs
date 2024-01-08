using Goodleap.Employee.Service.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace Goodleap.Employee.Api.Controllers
{
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPermission()
        {
            return Ok(await _permissionService.GetAllPermission());
        }
    }
}
