namespace manage_tasks.src.models.requests
{
    public class DropTask()
    {
        public int UserId { get; set; }

        public int TaskId { get; set; }

        public int ColumnId { get; set; }
    }
}