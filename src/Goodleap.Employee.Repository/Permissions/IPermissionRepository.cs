using Goodleap.Employee.Repository.Models;

namespace Goodleap.Employee.Repository.Permissions
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionAsync(Guid permissionId);
        void UpdatePermission(Permission permission);
        Task<List<Permission>> GetAllPermissionsAsync();
        Task SaveChanges();
    }
}
