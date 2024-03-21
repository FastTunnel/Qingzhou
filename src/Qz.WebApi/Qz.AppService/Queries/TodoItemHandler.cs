﻿using MediatR;
using Qz.Application.Contracts.Dtos;
using Qz.Application.Contracts.Handlers;
using Qz.Application.Contracts.Repositorys;
using Qz.Domain;

namespace Qz.AppService.Queries
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
