using System.ComponentModel.DataAnnotations.Schema;

namespace Goodleap.Employee.Core.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public virtual PermissionType PermissionType { get; set; }
    }
}
