namespace Qz.Persistence.Entitys
{
    public class TodoItemEntity
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Summary { get; set; }
    }
}
