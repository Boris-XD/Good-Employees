namespace Goodleap.Employee.Api.DTOs
{
    public class UpdatePermissionDto
    {
        public Guid EmployeeId { get; set; }

        public List<Guid> Permissions { get; set; }
    }
}
