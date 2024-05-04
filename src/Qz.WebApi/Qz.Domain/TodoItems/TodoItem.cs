using Qz.Domain.Base.Repositorys;

namespace Qz.Domain.TodoItems
{
    public class TodoItem : Aggregate<long>
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }
    }
}
