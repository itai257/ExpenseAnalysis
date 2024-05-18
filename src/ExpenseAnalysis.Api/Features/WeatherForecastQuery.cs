using ExpenseAnalysis.Api.Infrastructure;
using MediatR;

namespace ExpenseAnalysis.Api.Features;

public class WeatherForecastEndpoint : Endpoint<GetWeatherForecastQuery, WeatherForecast>
{
    public override void MapEndpoint(IEndpointRouteBuilder builder)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        builder
            .MapGroup("Group1")
            .WithTags("Groupp1")
            .MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}

public class GetWeatherForecastQuery : IRequest<WeatherForecast>
{

}