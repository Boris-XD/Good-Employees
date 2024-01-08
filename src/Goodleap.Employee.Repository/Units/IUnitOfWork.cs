using Goodleap.Employee.Repository.Permissions;

namespace Goodleap.Employee.Repository.Units
{
    public interface IUnitOfWork
    {
        IPermissionRepository permissionRepository { get; }

        Task SaveChangesAsync();
    }
}
