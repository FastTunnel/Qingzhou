namespace Qz.Domain.Domains
{
    public class TodoItemDO
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }
    }
}
