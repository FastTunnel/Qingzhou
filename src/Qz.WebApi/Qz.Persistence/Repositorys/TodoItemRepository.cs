using Qz.Domain.Models;
using Qz.Domain.Repositorys;
using Qz.Domain.Types;
using Qz.Persistence.Converters;
using Qz.Persistence.Entitys;


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
            return new TodoItemEntity()
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


        public long Save(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
