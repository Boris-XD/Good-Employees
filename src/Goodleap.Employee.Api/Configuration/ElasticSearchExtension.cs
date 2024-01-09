using Goodleap.Employee.Api.DTOs;
using Nest;

namespace Goodleap.Employee.Api.Configuration
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ElasticSettings:baseUrl"];
            var index = configuration["ElasticSettings:defaultIndex"];

            var settings = new ConnectionSettings(new Uri(baseUrl ?? "")).DefaultIndex(index);
            settings.EnableApiVersioningHeader();

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, index);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<UpdatePermissionDto>(x => x.AutoMap())
            );
        }
    }
}
