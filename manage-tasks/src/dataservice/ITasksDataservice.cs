public interface ITasksDataservice 
{

    void GetTask(int taskId, int userId);

    void GetTasks(int userId);
    
    void CreateTask(CreateTask createTaskRequest);

    void UpdateTask(UpdateTask updateTaskRequest);

    void DeleteTask(DeleteTask deleteTaskRequest);
}