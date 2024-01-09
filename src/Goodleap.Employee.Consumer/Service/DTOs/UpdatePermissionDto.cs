namespace Goodleap.Employee.Consumer.Service.DTOs
{
    public class UpdatePermissionDto
    {
        public Guid EmployeeId { get; set; }

        public List<Guid> Permissions { get; set; }
    }
}
