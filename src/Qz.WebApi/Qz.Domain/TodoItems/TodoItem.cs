using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;

namespace Qz.Domain.TodoItems
{
    public class TodoItem : Aggregate<long>
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }
    }
}
