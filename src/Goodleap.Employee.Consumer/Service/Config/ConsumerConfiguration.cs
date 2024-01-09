using Confluent.Kafka;

namespace Goodleap.Employee.Consumer.Service.Config
{
    public static class ConsumerConfiguration
    {
        public static string GroupId = "permission-consumer-group";
        public static string BootstrapServers = "localhost:9092";
        public static AutoOffsetReset AutoOffsetReset = AutoOffsetReset.Earliest;
    }

    public static class EmployeeConsumer
    {
        public static string EmployeePermission = "employee-permission";
    }
}
