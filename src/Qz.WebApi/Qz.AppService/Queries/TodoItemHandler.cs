using MediatR;
using Qz.Application.Contracts;
using Qz.Domain;
using Qz.Persistence;

namespace Qz.AppService.Queries
{
    public class TodoItemHandler : ITodoItemHandler
    {
        readonly TodoItemRepository todoItemRepository;

        public TodoItemHandler(TodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public Task<TodoItemResponse> Handle(TodoItemRequest request, CancellationToken cancellationToken)
        {
            var res = todoItemRepository.Fine(request.Id);

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
