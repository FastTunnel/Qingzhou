using Qz.Domain.Repository.Base;
using Qz.Domain.Types;

namespace Qz.Domain.Domains
{
    public class TodoItem : Aggregate<Identifier>
    {
        public Identifier Id { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }

        public Identifier GetId()
        {
            return Id;
        }
    }
}
