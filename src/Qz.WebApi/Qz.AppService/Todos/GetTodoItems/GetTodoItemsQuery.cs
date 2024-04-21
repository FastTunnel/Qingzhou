using Qz.Application.Base.Queries;
using Qz.Application.Contracts.Dtos;

namespace Qz.Application.Todos.GetTodoItems
{
    public class GetTodoItemsQuery : IQuery<TodoItemResponse>
    {
        public long Id { get; set; }
    }
}
