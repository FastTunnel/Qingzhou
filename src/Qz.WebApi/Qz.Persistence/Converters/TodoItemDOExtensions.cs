using Qz.Domain.Models;
using Qz.Persistence.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Converters
{
    public static class TodoItemDOExtensions
    {
        public static TodoItem ToTodoItem(this TodoItemEntity userDo)
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
