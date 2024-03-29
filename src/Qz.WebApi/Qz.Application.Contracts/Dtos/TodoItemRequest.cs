﻿using MediatR;

namespace Qz.Application.Contracts.Dtos
{
    public class TodoItemRequest : IRequest<TodoItemResponse>
    {
        public long Id { get; set; }
    }
}
