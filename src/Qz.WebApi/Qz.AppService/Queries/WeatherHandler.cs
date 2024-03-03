using MediatR;
using Qz.Domain;

namespace Qz.AppService.Queries
{
    public class WeatherHandler : IRequestHandler<Weather, IEnumerable<WeatherForecast>>
    {
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecast>> Handle(Weather request, CancellationToken cancellationToken)
        {
            var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

            return Task.FromResult(res);
        }
    }
}
