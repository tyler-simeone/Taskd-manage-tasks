using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    IRequestValidator _validator;
    ITasksRepository _tasksRepository;

    public TasksController(ITasksRepository tasksRepository, IRequestValidator requestValidator)
    {
        _validator = requestValidator;
        _tasksRepository = tasksRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id, int userId)
    {
        if (_validator.ValidateGetTask(id, userId))
        {
            try
            {
                _tasksRepository.GetTask(id, userId);
                return Ok($"Task with ID {id} retrieved successfully");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                _tasksRepository.GetTasks(userId);
                return Ok("GetAllTasks");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        else 
        {
            return BadRequest("User ID is required.");
        }
    }
    
    [HttpPost]
    public IActionResult CreateTask(CreateTask createTaskRequest)
    {
        if (_validator.ValidateCreateTask(createTaskRequest))
        {
            try
            {
                _tasksRepository.CreateTask(createTaskRequest);
                return Ok("Task Created");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        else 
        {
            return BadRequest("CreateTaskRequest is required.");
        }
    }

    [HttpPut]
    public IActionResult UpdateTask(UpdateTask updateTaskRequest)
    {
        if (_validator.ValidateUpdateTask(updateTaskRequest))
        {
            try
            {
                _tasksRepository.UpdateTask(updateTaskRequest);
                return Ok("Task Updated");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        else 
        {
            return BadRequest("UpdateTask is required.");
        }
    }

    [HttpDelete]
    public IActionResult DeleteTask(DeleteTask deleteTaskRequest)
    {
        if (_validator.ValidateDeleteTask(deleteTaskRequest))
        {
            try
            {
                _tasksRepository.DeleteTask(deleteTaskRequest);
                return Ok("Task Deleted");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        else 
        {
            return BadRequest("DeleteTask is required.");
        }
    }
}