using Confluent.Kafka;
using Goodleap.Employee.Consumer.Service.Config;
using Goodleap.Employee.Consumer.Service.DTOs;
using Goodleap.Employee.Consumer.Service.ElasticSearchs;
using Newtonsoft.Json;

namespace Goodleap.Employee.Consumer.Service.Consumers
{
    public class ConsumerService
    {
        private readonly ConsumerConfig _consumerConfig;
        
        public ConsumerService()
        {
            _consumerConfig = new ConsumerConfig()
            {
                GroupId = ConsumerConfiguration.GroupId,
                BootstrapServers = ConsumerConfiguration.BootstrapServers,
                AutoOffsetReset = ConsumerConfiguration.AutoOffsetReset,
            };
        }

        public void Consumer()
        {
            try
            {
                using var consumer = new ConsumerBuilder<Null, string>(_consumerConfig).Build();

                consumer.Subscribe(EmployeeConsumer.EmployeePermission);
                var response = consumer.Consume(new CancellationTokenSource().Token);
            
                if (response.Message != null)
                {
                    var result = JsonConvert.DeserializeObject<UpdatePermissionDto>(response.Message.Value);
                    var elasticsearch = ElasticSearchService.Initial("employee-permission");
                    elasticsearch.CreateIndexIfNotExists("employee-permission").GetAwaiter().GetResult();
                    elasticsearch.AddOrUpdate<UpdatePermissionDto>(result).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
