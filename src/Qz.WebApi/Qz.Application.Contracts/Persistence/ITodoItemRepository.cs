using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qz.Domain.Domains;

namespace Qz.Application.Contracts.Repositorys
{
    public interface ITodoItemRepository
    {
        TodoItem Fine(long itemid);

        void Save(TodoItem item);
    }
}
