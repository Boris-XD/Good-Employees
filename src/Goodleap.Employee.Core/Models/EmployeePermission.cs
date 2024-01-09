using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goodleap.Employee.Core.Models
{
    public class EmployeePermission
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }
    }
}
