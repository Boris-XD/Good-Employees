using Goodleap.Employee.Core.EmployeePermissions;
using Goodleap.Employee.Core.Permissions;

namespace Goodleap.Employee.Core.Units
{
    public interface IUnitOfWork
    {
        IPermissionRepository permissionRepository { get; }

        IEmployeePermissionRepository employeePermissionRepository { get; }

        Task SaveChangesAsync();
    }
}
