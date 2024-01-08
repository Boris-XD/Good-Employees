using Goodleap.Employee.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Goodleap.Employee.Core.Permissions
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public PermissionRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<List<Permission>> GetAllPermissionsAsync()
        {
            return await _employeeDbContext.Permissions
                .Include(permission => permission.PermissionType)
                .ToListAsync();
        }

        public async Task<Permission> GetPermissionAsync(Guid permissionId)
        {
            return await _employeeDbContext.Permissions.FirstOrDefaultAsync(permission => permission.Id == permissionId);
        }

        public void UpdatePermission(Permission permission)
        {
           _employeeDbContext.Permissions.Update(permission);
        }

        public async Task SaveChanges()
        {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
