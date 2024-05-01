public interface ITasksRepository 
{
    Task<Task> GetTask(int taskId, int userId);

    Task<TaskList> GetTasks(int columnId);
    
    void CreateTask(CreateTask createTaskRequest);

    void UpdateTask(UpdateTask updateTaskRequest);

    void DeleteTask(int taskId, int userId);
}