using manage_tasks.src.models;
using manage_tasks.src.models.requests;

namespace manage_tasks.src.repository
{
    public interface ITasksRepository
    {
        Task<models.Task> GetTask(int taskId, int userId);

        Task<TaskList> GetTasks(int columnId, int boardId);

        void CreateTask(CreateTask createTaskRequest);

        void UpdateTask(UpdateTask updateTaskRequest);
        
        void DropTask(DropTask dropTaskRequest);

        void DeleteTask(int taskId, int userId);
    }
}