using Goodleap.Employee.Core.EmployeePermissions;
using Goodleap.Employee.Core.Models;
using Goodleap.Employee.Core.Permissions;

namespace Goodleap.Employee.Core.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private IPermissionRepository? _permissionRepository;
        private IEmployeePermissionRepository? _employeePermissionRepository;

        public UnitOfWork(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public IPermissionRepository permissionRepository
        {
            get
            {
                if (_permissionRepository == null)
                {
                    _permissionRepository = new PermissionRepository(_employeeDbContext);
                }

                return _permissionRepository;
            }
        }

        public IEmployeePermissionRepository employeePermissionRepository
        {
            get
            {
                if (_employeePermissionRepository == null)
                {
                    _employeePermissionRepository = new EmployeePermissionRepository(_employeeDbContext);
                }

                return _employeePermissionRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
