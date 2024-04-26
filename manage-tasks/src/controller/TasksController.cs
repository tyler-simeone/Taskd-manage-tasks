using Microsoft.AspNetCore.Mvc;

public class TasksController 
{
    RequestValidator _validator;
    TasksRepository _tasksRepository;

    public TasksController()
    {
        _tasksRepository = new TasksRepository();
    }

    public void GetTask([FromQuery] Guid taskId, [FromQuery] Guid userId)
    {
        if (_validator.ValidateGetTask(taskId, userId))
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

    public void GetTasks([FromQuery] Guid userId)
    {
        if (_validator.ValidateGetTasks(userId))
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
    
    public void CreateTask(CreateTask createTaskRequest)
    {
        if (_validator.ValidateCreateTask(createTaskRequest))
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

    public void UpdateTask(UpdateTask updateTaskRequest)
    {
        if (_validator.ValidateUpdateTask(updateTaskRequest))
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

    public void DeleteTask(DeleteTask deleteTaskRequest)
    {
        if (_validator.ValidateDeleteTask(deleteTaskRequest))
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
}