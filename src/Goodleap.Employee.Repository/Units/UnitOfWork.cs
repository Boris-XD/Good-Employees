using Goodleap.Employee.Repository.Models;
using Goodleap.Employee.Repository.Permissions;

namespace Goodleap.Employee.Repository.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private IPermissionRepository? _permissionRepository;

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

        public async Task SaveChangesAsync()
        {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
