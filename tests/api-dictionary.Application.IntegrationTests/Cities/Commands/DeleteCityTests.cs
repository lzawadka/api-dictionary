using System.Threading.Tasks;
using api_dictionary.Application.Cities.Commands.Create;
using api_dictionary.Application.Cities.Commands.Delete;
using api_dictionary.Application.Common.Exceptions;
using api_dictionary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static api_dictionary.Application.IntegrationTests.Testing;

namespace api_dictionary.Application.IntegrationTests.Cities.Commands
{
    public class DeleteCityTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCityId()
        {
            var command = new DeleteCityCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCity()
        {
            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Kayseri"
            });

            await SendAsync(new DeleteCityCommand
            {
                Id = city.Data.Id
            });

            var list = await FindAsync<City>(city.Data.Id);

            list.Should().BeNull();
        }
    }
}
