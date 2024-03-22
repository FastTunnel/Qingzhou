using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qz.Domain.Domains;
using Qz.Domain.Repository.Base;
using Qz.Domain.Types;

namespace Qz.Application.Contracts.Repositorys
{
    public interface ITodoItemRepository : IRepository<TodoItem, Identifier>
    {
    }
}
