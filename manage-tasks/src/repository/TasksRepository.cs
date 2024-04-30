public class TasksRepository : ITasksRepository
{
    ITasksDataservice _tasksDataservice;

    public TasksRepository(ITasksDataservice tasksDataservice)
    {
        _tasksDataservice = tasksDataservice;
    }

    public void GetTask(int taskId, int userId)
    {
        try
        {
            _tasksDataservice.GetTask(taskId, userId);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public void GetTasks(int userId)
    {
        try
        {
            _tasksDataservice.GetTasks(userId);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
    
    public void CreateTask(CreateTask createTaskRequest)
    {
        try
        {
            _tasksDataservice.CreateTask(createTaskRequest);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public void UpdateTask(UpdateTask updateTaskRequest)
    {
        try
        {
            _tasksDataservice.UpdateTask(updateTaskRequest);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public void DeleteTask(DeleteTask deleteTaskRequest)
    {
        try
        {
            _tasksDataservice.DeleteTask(deleteTaskRequest);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}