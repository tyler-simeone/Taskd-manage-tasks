using manage_tasks.src.models;
using manage_tasks.src.repository;
using Microsoft.AspNetCore.Mvc;

namespace manage_tasks.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        IRequestValidator _validator;
        ITasksRepository _tasksRepository;

        public TasksController(ITasksRepository tasksRepository, IRequestValidator requestValidator)
        {
            _validator = requestValidator;
            _tasksRepository = tasksRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(models.Task), StatusCodes.Status200OK)]
        public async Task<ActionResult<models.Task>> GetTask(int id, int userId)
        {
            if (_validator.ValidateGetTask(id, userId))
            {
                try
                {
                    models.Task task = await _tasksRepository.GetTask(id, userId);
                    Console.WriteLine($"Task: {task.TaskDescription}");
                    return Ok(task);
                }
                catch (Exception ex)
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
        [ProducesResponseType(typeof(TaskList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskList>> GetTasks(int columnId)
        {
            if (_validator.ValidateGetTasks(columnId))
            {
                try
                {
                    TaskList taskList = await _tasksRepository.GetTasks(columnId);
                    return Ok(taskList);
                }
                catch (Exception ex)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateTask(CreateTask createTaskRequest)
        {
            if (_validator.ValidateCreateTask(createTaskRequest))
            {
                try
                {
                    _tasksRepository.CreateTask(createTaskRequest);
                    return Ok("Task Created");
                }
                catch (Exception ex)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTask(UpdateTask updateTaskRequest)
        {
            if (_validator.ValidateUpdateTask(updateTaskRequest))
            {
                try
                {
                    _tasksRepository.UpdateTask(updateTaskRequest);
                    return Ok("Task Updated");
                }
                catch (Exception ex)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTask(int taskId, int userId)
        {
            if (_validator.ValidateDeleteTask(taskId, userId))
            {
                try
                {
                    _tasksRepository.DeleteTask(taskId, userId);
                    return Ok("Task Deleted");
                }
                catch (Exception ex)
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
}