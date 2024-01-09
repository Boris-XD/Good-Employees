using Confluent.Kafka;
using Goodleap.Employee.Consumer.Service.DTOs;
using Newtonsoft.Json;

namespace Goodleap.Employee.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig()
            {
                GroupId = "permission-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Null, string>(config).Build();

            consumer.Subscribe("employee-permission");

            var token = new CancellationTokenSource();

            try
            {
                while (true)
                {
                    var response = consumer.Consume(token.Token);

                    if(response.Message != null)
                    {
                        var result = JsonConvert.DeserializeObject<UpdatePermissionDto>(response.Message.Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}