using Goodleap.Employee.Core.Models;

namespace Goodleap.Employee.Core.Permissions
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionAsync(Guid permissionId);
        void UpdatePermission(Permission permission);
        Task<List<Permission>> GetAllPermissionsAsync();
        Task SaveChanges();
    }
}
