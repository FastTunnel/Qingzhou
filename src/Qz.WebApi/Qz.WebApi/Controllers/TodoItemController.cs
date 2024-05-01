using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Todos.GetTodoItems;
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
        public async Task<QzResponse<TodoItemResponse>> Get([FromServices] IMediator mediator, [Range(1, double.MaxValue)] long Id)
        {
            return Success(await mediator.Send(new GetTodoItemsQuery { Id = Id }));
        }

        [HttpPut]
        public QzResponse<string> Put(TodoDto item)
        {
            return Success($"insert");
        }

        [HttpPost]
        public QzResponse<string> Post(TodoDto item)
        {
            return Success($"updated");
        }

        [HttpDelete]
        public QzResponse<string> Delete([Range(1, double.MaxValue)] long Id)
        {
            return Success($"deleted");
        }
    }
}
