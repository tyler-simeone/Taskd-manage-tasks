using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    RequestValidator _validator;
    TasksRepository _tasksRepository;

    public TasksController()
    {
        _validator = new RequestValidator();
        _tasksRepository = new TasksRepository();
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id, int userId)
    {
        if (_validator.ValidateGetTask(id))
        {
            try
            {
                return Ok($"Task with ID {id} retrieved successfully");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        else 
        {
            return BadRequest("Task ID is required.");
        }
    }

    [HttpGet]
    public IActionResult GetTasks(int userId)
    {
        if (_validator.ValidateGetTasks(userId))
        {
            try
            {
                // Retrieve all tasks logic
                return Ok("GetAllTasks");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        else 
        {
            return BadRequest("User ID is required.");
        }
    }
    
    [HttpPost]
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

    [HttpPut]
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

    [HttpDelete]
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