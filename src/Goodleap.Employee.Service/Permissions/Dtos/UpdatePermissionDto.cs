namespace Goodleap.Employee.Service.Permissions.Dtos
{
    public class UpdatePermissionDto
    {
        public Guid EmployeeId { get; set; }

        public List<Guid> Permissions { get; set; }
    }
}
