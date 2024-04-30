using MySql.Data.MySqlClient;

public class TasksDataservice : ITasksDataservice
{
    private IConfiguration _configuration;
    // private string _connectionString;
    
    public TasksDataservice(IConfiguration configuration)
    {
         _configuration = configuration;
    }

    public void GetTask(int taskId, int userId)
    {
        var connectionString = _configuration.GetConnectionString("ProjectBLocalConnection");
        using MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();

            Console.WriteLine("Connection successful!");
            
            // Perform database operations here
            
            connection.Close();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
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