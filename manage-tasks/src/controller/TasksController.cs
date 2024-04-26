public class TasksController {
    TasksRepository _tasksRepository;

    public TasksController()
    {
        _tasksRepository = new TasksRepository();
    }
}