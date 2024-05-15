using manage_tasks.src.models;

namespace manage_tasks.src.dataservice
{
    public interface ITasksDataservice
    {

        Task<models.Task> GetTask(int taskId, int userId);

        Task<TaskList> GetTasks(int userId);

        void CreateTask(CreateTask createTaskRequest);

        void UpdateTask(UpdateTask updateTaskRequest);

        void DeleteTask(int taskId, int userId);
    }
}