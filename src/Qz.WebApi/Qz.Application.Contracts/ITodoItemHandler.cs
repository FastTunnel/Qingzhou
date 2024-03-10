using MediatR;
using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts
{
    public interface ITodoItemHandler : IRequestHandler<TodoItemRequest, TodoItemResponse>
    {
    }
}
