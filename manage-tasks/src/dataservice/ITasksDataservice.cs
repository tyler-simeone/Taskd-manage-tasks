public interface ITasksDataservice 
{

    Task<Task> GetTask(int taskId, int userId);

    Task<TaskList> GetTasks(int userId);
    
    void CreateTask(CreateTask createTaskRequest);

    void UpdateTask(UpdateTask updateTaskRequest);

    void DeleteTask(DeleteTask deleteTaskRequest);
}