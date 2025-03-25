using manage_tasks.src.models;
using manage_tasks.src.models.requests;

namespace manage_tasks.src.dataservice
{
    public interface ITasksDataservice
    {

        Task<models.Task> GetTask(int taskId, int userId);

        Task<TaskList> GetTasks(int userId);

        Task<List<TaskTag>> GetTaskTags(int columnId, int boardId);

        Task<int> CreateTask(CreateTask createTaskRequest);

        void UpdateTask(UpdateTask updateTaskRequest);
        
        void DropTask(DropTask dropTaskRequest);

        void DeleteTask(int taskId, int userId);
    }
}