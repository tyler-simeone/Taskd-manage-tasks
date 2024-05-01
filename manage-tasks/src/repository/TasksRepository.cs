public class TasksRepository : ITasksRepository
{
    ITasksDataservice _tasksDataservice;

    public TasksRepository(ITasksDataservice tasksDataservice)
    {
        _tasksDataservice = tasksDataservice;
    }

    public async Task<Task> GetTask(int taskId, int userId)
    {
        try
        {
            Task task = await _tasksDataservice.GetTask(taskId, userId);
            return task;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<TaskList> GetTasks(int columnId)
    {
        try
        {
            TaskList taskList = await _tasksDataservice.GetTasks(columnId);
            return taskList;
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

    public void DeleteTask(int taskId, int userId)
    {
        try
        {
            _tasksDataservice.DeleteTask(taskId, userId);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}