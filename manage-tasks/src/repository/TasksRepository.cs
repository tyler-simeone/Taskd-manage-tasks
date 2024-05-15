using manage_tasks.src.dataservice;
using manage_tasks.src.models;

namespace manage_tasks.src.repository
{
    public class TasksRepository : ITasksRepository
    {
        ITasksDataservice _tasksDataservice;

        public TasksRepository(ITasksDataservice tasksDataservice)
        {
            _tasksDataservice = tasksDataservice;
        }

        public async Task<models.Task> GetTask(int taskId, int userId)
        {
            try
            {
                models.Task task = await _tasksDataservice.GetTask(taskId, userId);
                return task;
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}