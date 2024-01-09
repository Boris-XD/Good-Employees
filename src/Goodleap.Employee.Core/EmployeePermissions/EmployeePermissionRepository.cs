using Goodleap.Employee.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Goodleap.Employee.Core.EmployeePermissions
{
    public class EmployeePermissionRepository : IEmployeePermissionRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeePermissionRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<ICollection<EmployeePermission>> GetEmployeePermissionByEmployeeIdAsync(Guid employeeId)
        {
            return await _employeeDbContext.EmployeePermissions
                .Where(employeePermission => employeePermission.EmployeeId == employeeId)
                .ToListAsync();
        }

        public void UpdateEmployeePermission(EmployeePermission employeePermission)
        {
            _employeeDbContext.EmployeePermissions.Update(employeePermission);
        }

        public void DeleteEmployeePermission(EmployeePermission employeePermission)
        {
            _employeeDbContext.EmployeePermissions.Remove(employeePermission);
        }

        public void AddEmployeePermissionAsync(EmployeePermission employeePermission)
        {
            _employeeDbContext.EmployeePermissions.Add(employeePermission);
        }

        public async Task SaveChanges()
        {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
