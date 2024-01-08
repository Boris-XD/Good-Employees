using Microsoft.EntityFrameworkCore;

namespace Goodleap.Employee.Core.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }
    }
}
