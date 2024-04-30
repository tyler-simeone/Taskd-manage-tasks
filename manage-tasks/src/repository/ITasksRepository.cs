public interface ITasksRepository 
{
    void GetTask(Guid taskId, Guid userId);

    void GetTasks(Guid userId);
    
    void CreateTask(CreateTask createTaskRequest);

    void UpdateTask(UpdateTask updateTaskRequest);

    void DeleteTask(DeleteTask deleteTaskRequest);
}