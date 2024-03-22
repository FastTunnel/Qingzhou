using Qz.Application.Contracts.Repositorys;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using Qz.Persistence.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Repositorys
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public void Attach(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }

        public TodoItem Find(Identifier id)
        {
            return new TodoItemDO()
            {
                Id = 10000,
                Title = "ddd-sample",
                Summary = "Summary"
            }.ToTodoItem();
        }

        public void Remove(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }


        public void Save(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
