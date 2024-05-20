using manage_tasks.src.models;

namespace manage_tasks.src.repository
{
    public interface ITasksRepository
    {
        Task<models.Task> GetTask(int taskId, int userId);

        Task<TaskList> GetTasks(int columnId);

        void CreateTask(CreateTask createTaskRequest);

        void UpdateTask(UpdateTask updateTaskRequest);

        void DeleteTask(int taskId, int userId);
    }
}