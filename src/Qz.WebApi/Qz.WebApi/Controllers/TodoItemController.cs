using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts;
using Qz.Application.Contracts.Base;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    public class TodoItemController : BaseController
    {
        private readonly ILogger<TodoItemController> _logger;

        public TodoItemController(ILogger<TodoItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<QzResponse> Get([FromServices] IMediator mediator, [Range(1, double.MaxValue)] long Id)
        {
            return Success(await mediator.Send(new TodoItemRequest { Id = Id }));
        }

        [HttpPut]
        public QzResponse Put(TodoDto item)
        {
            return Success($"insert");
        }

        [HttpPost]
        public QzResponse Post(TodoDto item)
        {
            return Success($"updated");
        }

        [HttpDelete]
        public QzResponse Delete([Range(1, double.MaxValue)] long Id)
        {
            return Success($"deleted");
        }
    }
}
