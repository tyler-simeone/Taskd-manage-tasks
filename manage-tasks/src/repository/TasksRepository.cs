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
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void GetTasks(int userId)
    {
        
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    
    public void CreateTask(CreateTask createTaskRequest)
    {
        
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void UpdateTask(UpdateTask updateTaskRequest)
    {
        
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void DeleteTask(DeleteTask deleteTaskRequest)
    {
        
        try
        {
            
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}