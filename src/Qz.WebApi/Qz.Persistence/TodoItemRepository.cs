using Qz.Application.Contracts.Repositorys;
using Qz.Domain.Domains;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
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
            return new TodoItem()
            {
                Id = id,
                Title = "ddd-sample",
                Summary = "Summary"
            };
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
