using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain
{
    public interface ITodoItemRepository
    {
        TodoItem Fine(long itemid);

        void Save(TodoItem item);
    }
}
