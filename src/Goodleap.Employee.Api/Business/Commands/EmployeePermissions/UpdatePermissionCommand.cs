using Goodleap.Employee.Api.DTOs;
using MediatR;

namespace Goodleap.Employee.Api.Business.Commands.EmployeePermissions;

public record UpdatePermissionCommand(UpdatePermissionDto UpdatePermissionDto) : IRequest<UpdatePermissionDto>;
