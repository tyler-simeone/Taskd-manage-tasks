using manage_tasks.src.clients;
using manage_tasks.src.dataservice;
using manage_tasks.src.models;
using manage_tasks.src.models.requests;

namespace manage_tasks.src.repository
{
    public class TasksRepository : ITasksRepository
    {
        readonly ITasksDataservice _tasksDataservice;
        readonly ITagsClient _tagsClient;

        public TasksRepository(ITasksDataservice tasksDataservice,
                               ITagsClient tagsClient)
        {
            _tasksDataservice = tasksDataservice;
            _tagsClient = tagsClient;
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

        public async Task<TaskList> GetTasks(int columnId, int boardId)
        {
            try
            {
                TaskList taskList = await _tasksDataservice.GetTasks(columnId);
                
                var tagsOnTasks = await _tasksDataservice.GetTaskTags(columnId, boardId);

                taskList.Tasks.ForEach(task => 
                {
                    var taskTags = tagsOnTasks.Where(tt => tt.TaskId == task.TaskId).ToList();
                    task.TaskTags = taskTags;
                });

                return taskList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async void CreateTask(CreateTask createTaskRequest)
        {
            try
            {
                var taskId = await _tasksDataservice.CreateTask(createTaskRequest);

                if (createTaskRequest.TagId != null)
                    await _tagsClient.AddTagToTask(createTaskRequest.UserId, createTaskRequest.BoardId, (int)createTaskRequest.TagId, taskId);
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
        
        public void DropTask(DropTask dropTaskRequest)
        {
            try
            {
                _tasksDataservice.DropTask(dropTaskRequest);
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