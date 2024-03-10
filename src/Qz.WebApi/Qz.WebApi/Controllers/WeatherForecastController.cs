using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts;
using Qz.AppService.Queries;
using Qz.Domain;
using System.Net.NetworkInformation;

namespace Qz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<WeatherResponse> Get([FromServices] IMediator mediator)
        {
            return await mediator.Send(new WeatherRequest());
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public void Post()
        {

        }
    }
}
