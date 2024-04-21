using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;

namespace Qz.Domain.TodoItems
{
    public interface ITodoItemRepository : IRepository<TodoItem, Identifier>
    {
    }
}
