public class RequestValidator
{
    public RequestValidator()
    {
        
    }

    public bool ValidateGetTask(Guid taskId, Guid userId)
    {
        return true;
    }

    public bool ValidateGetTasks(Guid userId)
    {
        return true;
    }

    public bool ValidateCreateTask(CreateTask createTaskRequest)
    {
        return true;
    }
    
    public bool ValidateUpdateTask(UpdateTask updateTaskRequest)
    {
        return true;
    }
    
    public bool ValidateDeleteTask(DeleteTask deleteTaskRequest)
    {
        return true;
    }
}