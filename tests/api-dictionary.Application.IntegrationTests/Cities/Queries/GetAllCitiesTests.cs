using System.Threading.Tasks;
using api_dictionary.Application.Cities.Queries.GetCities;
using api_dictionary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static api_dictionary.Application.IntegrationTests.Testing;

namespace api_dictionary.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCitiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await AddAsync(new City
            {
                Name = "Manisa",
            });

            var query = new GetAllCitiesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}