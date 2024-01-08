using Goodleap.Employee.Repository.Models;
using Goodleap.Employee.Repository.Units;

namespace Goodleap.Employee.Service.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Permission>> GetAllPermission()
        {
            return await _unitOfWork.permissionRepository.GetAllPermissionsAsync();
        }
    }
}
