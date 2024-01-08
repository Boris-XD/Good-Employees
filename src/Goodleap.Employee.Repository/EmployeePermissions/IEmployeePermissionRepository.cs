using Goodleap.Employee.Core.Models;

namespace Goodleap.Employee.Core.EmployeePermissions
{
    public interface IEmployeePermissionRepository
    {
        Task<ICollection<EmployeePermission>> GetEmployeePermissionByEmployeeIdAsync(Guid employeeId);
        void AddEmployeePermissionAsync(EmployeePermission employeePermission);
        void UpdateEmployeePermission(EmployeePermission employeePermission);
        void DeleteEmployeePermission(EmployeePermission employeePermission);
        Task SaveChanges();
    }
}
