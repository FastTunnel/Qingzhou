﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qz.Domain.Base.Repositorys;

namespace Qz.Domain.TodoItems
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
    }
}
