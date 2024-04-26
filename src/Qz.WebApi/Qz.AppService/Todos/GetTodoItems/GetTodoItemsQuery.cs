using Qz.Application.Base.Queries;

namespace Qz.Application.Todos.GetTodoItems
{
    public class GetTodoItemsQuery : IQuery<TodoItemResponse>
    {
        public long Id { get; set; }
    }
}
