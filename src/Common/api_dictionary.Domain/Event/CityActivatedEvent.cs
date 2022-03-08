using api_dictionary.Domain.Common;
using api_dictionary.Domain.Entities;

namespace api_dictionary.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
