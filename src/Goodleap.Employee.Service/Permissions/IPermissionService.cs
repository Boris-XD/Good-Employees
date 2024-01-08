using Goodleap.Employee.Core.Models;

namespace Goodleap.Employee.Service.Permissions
{
    public interface IPermissionService
    {
        Task<List<Permission>> GetAllPermission();
    }
}
