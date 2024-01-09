using Nest;

namespace Goodleap.Employee.Consumer.Service.ElasticSearchs
{
    public class ElasticSearchService
    {
        public static ElasticClient CreateClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200/"))
                .EnableApiVersioningHeader();
            
            return new ElasticClient(connectionSettings);
        }

        public static ElasticSearch Initial(string index)
        {
            var client = CreateClient();

            return new ElasticSearch(client, index);
        }
    }
}
