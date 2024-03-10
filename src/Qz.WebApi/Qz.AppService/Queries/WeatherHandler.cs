using MediatR;
using Qz.Application.Contracts;
using Qz.Domain;

namespace Qz.AppService.Queries
{
    public class WeatherHandler : IRequestHandler<WeatherRequest, WeatherResponse>
    {
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherResponse> Handle(WeatherRequest request, CancellationToken cancellationToken)
        {
            var res = Enumerable.Range(1, 5).Select(index => new WeatherAggregateRoot
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

            return Task.FromResult(new WeatherResponse { 
                WeatherList = res,
            });
        }
    }
}
