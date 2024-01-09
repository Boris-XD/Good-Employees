namespace Goodleap.Employee.Api.Business.DomainEvents.Publishers
{
    public interface IPublishService
    {
        Task Publish<T>(string topic, T Object);
    }
}
