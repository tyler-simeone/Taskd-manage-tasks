namespace manage_tasks.src.models.requests
{
    public class AddTagToTask(int userId, int boardId, int tagId, int taskId)
    {
        public int UserId { get; set; } = userId;

        public int BoardId { get; set; } = boardId;

        public int TagId { get; set; } = tagId;

        public int TaskId { get; set; } = taskId;
    }
}