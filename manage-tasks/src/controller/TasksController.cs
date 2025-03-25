using manage_tasks.src.models;
using manage_tasks.src.models.requests;
using manage_tasks.src.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace manage_tasks.src.controller
{
    [Authorize]
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
            try
            {
                models.Task task = await _tasksRepository.GetTask(id, userId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpGet("/board/{boardId}/column/{columnId}")]
        [ProducesResponseType(typeof(TaskList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskList>> GetTasks(int boardId, int columnId)
        {
            try
            {
                TaskList taskList = await _tasksRepository.GetTasks(columnId, boardId);
                return Ok(taskList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateTask(CreateTask createTaskRequest)
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTask(UpdateTask updateTaskRequest)
        {
            try
            {
                _tasksRepository.UpdateTask(updateTaskRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        
        [HttpPut("dropped")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DropTask(DropTask dropTaskRequest)
        {
            try
            {
                _tasksRepository.DropTask(dropTaskRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTask(int taskId, int userId)
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
    }
}