using Goodleap.Employee.Api.DTOs;
using Goodleap.Employee.Api.Services.ElasticSearch;
using MediatR;
using Nest;

namespace Goodleap.Employee.Api.Business.Queries.EmployeePermissions
{
    public class GetAllEmployeePermissionCommandHandler : IRequestHandler<GetAllEmployeePermissionCommand, List<UpdatePermissionDto>>
    {
        private readonly IElasticClient _elasticClient;
        private readonly IConfiguration _configuration;

        public GetAllEmployeePermissionCommandHandler(IElasticClient elasticClient, IConfiguration configuration)
        {
            _elasticClient = elasticClient;
            _configuration = configuration;
        }

        public async Task<List<UpdatePermissionDto>> Handle(GetAllEmployeePermissionCommand request, CancellationToken cancellationToken)
        {
            var baseUrl = _configuration["ElasticSettings:baseUrl"];
            var connectionSettings = new ConnectionSettings(new Uri(baseUrl))
                .EnableApiVersioningHeader();
            var client = new ElasticClient(connectionSettings);
            var elasticsearch = new ElasticSearch(client, _configuration["ElasticSettings:defaultIndex"]);

            return await elasticsearch.GetAll<UpdatePermissionDto>();
        }
    }
}
