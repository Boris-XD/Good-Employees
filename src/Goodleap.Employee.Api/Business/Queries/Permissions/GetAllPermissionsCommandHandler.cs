using Goodleap.Employee.Core.Models;
using Goodleap.Employee.Core.Units;
using MediatR;

namespace Goodleap.Employee.Api.Business.Queries.Permissions
{
    public class GetAllPermissionsCommandHandler : IRequestHandler<GetAllPermissionsCommand, List<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPermissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Permission>> Handle(GetAllPermissionsCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.permissionRepository.GetAllPermissionsAsync();
        }
    }
}
