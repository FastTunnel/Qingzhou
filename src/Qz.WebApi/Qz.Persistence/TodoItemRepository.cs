using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public TodoItem Fine(long itemid)
        {
            return new TodoItem() { 
                Id = itemid,
                Title = "ddd-sample",
                Summary = "Summary"
            };
        }

        public void Save(TodoItem item)
        {
            // todo 保存数据到数据库
        }
    }
}
