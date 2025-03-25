namespace manage_tasks.src.clients
{
    public interface ITagsClient
    {
        Task<int> AddTagToTask(int userId, int boardId, int tagId, int taskId);
    }
}