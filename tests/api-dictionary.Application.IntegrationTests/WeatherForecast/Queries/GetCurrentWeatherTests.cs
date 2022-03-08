using System.Threading.Tasks;
using api_dictionary.Application.WeatherForecasts.Queries.GetCurrentWeatherForecastQuery;
using FluentAssertions;
using NUnit.Framework;
using static api_dictionary.Application.IntegrationTests.Testing;

namespace api_dictionary.Application.IntegrationTests.WeatherForecast.Queries
{
    public class GetCurrentWeatherTests : TestBase
    {
        //Removed bacuse of free token usage ended.!
        // [Test]
        // public async Task ShouldReturnCurrentWeather()
        // {
        //     var query = new GetCurrentWeatherForecastQuery
        //     {
        //         Id = 2172797,
        //         Lat = 1,
        //         Lon = 1,
        //         Q = "London%2Cuk"
        //     };
        //
        //     var result = await SendAsync(query);
        //
        //     result.Should().NotBeNull();
        //     result.Succeeded.Should().BeTrue();
        //     result.Data.weather.Count.Should().BeGreaterThan(0);
        // }
    }
}