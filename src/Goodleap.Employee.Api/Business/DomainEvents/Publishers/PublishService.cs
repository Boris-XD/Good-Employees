using Confluent.Kafka;
using Newtonsoft.Json;

namespace Goodleap.Employee.Api.Business.DomainEvents.Publishers
{
    public class PublishService : IPublishService
    {
        private readonly IConfiguration _configuration;

        public PublishService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Publish<T>(string topic, T Object)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                await producer.ProduceAsync(topic, new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(Object)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
