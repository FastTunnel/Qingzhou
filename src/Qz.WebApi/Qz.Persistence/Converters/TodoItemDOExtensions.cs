using Qz.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Converters
{
    public static class TodoItemDOExtensions
    {
        public static TodoItem ToTodoItem(this TodoItemDO userDo)
        {
            return new TodoItem
            {
                Id = new Domain.Types.Identifier(userDo.Id),
                Summary = userDo.Summary,
                Title = userDo.Title,
            };
        }
    }
}
