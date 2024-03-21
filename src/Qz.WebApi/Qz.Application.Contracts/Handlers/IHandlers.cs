using MediatR;
using Qz.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Handlers
{
    public interface ITodoItemHandler : IRequestHandler<TodoItemRequest, TodoItemResponse>
    {
    }

    public interface ILoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
    }

    public interface IAddTeamHandler : IRequestHandler<AddTeamRequest, AddTeamResponse>
    {
    }
}
