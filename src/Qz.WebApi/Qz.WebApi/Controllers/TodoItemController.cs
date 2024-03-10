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
    public class TodoItemController : ControllerBase
    {

        private readonly ILogger<TodoItemController> _logger;

        public TodoItemController(ILogger<TodoItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<TodoItemResponse> Get([FromServices] IMediator mediator,[FromQuery] TodoItemRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public void Post()
        {

        }
    }
}
