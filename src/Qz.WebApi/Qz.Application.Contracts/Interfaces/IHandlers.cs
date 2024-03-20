using MediatR;
using Qz.Application.Contracts.Dtos;
using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Interfaces
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
