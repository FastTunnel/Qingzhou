using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qz.Domain.Models;
using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;

namespace Qz.Domain.Repositorys
{
    public interface ITodoItemRepository : IRepository<TodoItem, Identifier>
    {
    }
}
