using MediatR;
using Qz.Domain;

namespace Qz.Application.Contracts
{
    public class TodoItemRequest : IRequest<TodoItemResponse>
    {
        public long Id { get; set; }
    }
}
