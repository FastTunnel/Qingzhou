using MediatR;
using Qz.Domain;

namespace Qz.AppService.Queries
{
    public class Weather : IRequest<IEnumerable<WeatherForecast>>
    {

    }
}
