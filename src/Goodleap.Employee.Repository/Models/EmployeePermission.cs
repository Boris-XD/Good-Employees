using System.ComponentModel.DataAnnotations.Schema;

namespace Goodleap.Employee.Repository.Models
{
    public class EmployeePermission
    {
        public Guid EmployeeId { get; set; }
        public ICollection<Permission> Permissions { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}
