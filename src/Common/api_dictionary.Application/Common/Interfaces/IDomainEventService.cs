using System.Threading.Tasks;
using api_dictionary.Domain.Common;

namespace api_dictionary.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
