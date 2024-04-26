using AutoMapper;
using Qz.Domain.TodoItems;
using Qz.Domain.Types;
using Qz.Persistence.Entitys;


namespace Qz.Persistence.Repositorys
{
    public class TodoItemRepository : ITodoItemRepository
    {
        IMapper mapper;
        public TodoItemRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Attach(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(TodoItem aggregate)
        {
            throw new NotImplementedException();
        }

        public TodoItem Find(long id)
        {
            return mapper.Map<TodoItem>(new TodoItemEntity()
            {
                Id = 10000,
                Title = "ddd-sample",
                Summary = "Summary"
            });
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
