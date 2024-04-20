using MediatR;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Domain;
using Qz.Domain.Repositorys;
using Qz.Domain.Types;

namespace Qz.Application.Queries
{
    public class TodoItemHandler : ITodoItemHandler
    {
        readonly ITodoItemRepository todoItemRepository;

        public TodoItemHandler(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public Task<TodoItemResponse> Handle(TodoItemRequest request, CancellationToken cancellationToken)
        {
            var res = todoItemRepository.Find(new Identifier(request.Id));

            return Task.FromResult(new TodoItemResponse
            {
                TodoInfo = new TodoDto
                {
                    Id = request.Id,
                    Summary = res.Summary,
                    Title = res.Title,
                },
            });
        }
    }
}
