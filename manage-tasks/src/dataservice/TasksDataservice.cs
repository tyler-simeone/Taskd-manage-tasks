using MySql.Data.MySqlClient;

public class TasksDataservice : ITasksDataservice
{
    private IConfiguration _configuration;
    
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
            using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("YourStoredProcedureName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters if needed
                command.Parameters.AddWithValue("@Parameter1", value1);
                command.Parameters.AddWithValue("@Parameter2", value2);

                connection.Open();
                
                // Execute the stored procedure
                command.ExecuteNonQuery();
                
                // If the stored procedure returns a value, you can retrieve it
                // For example, if the stored procedure returns a single value
                // int result = (int)command.ExecuteScalar();
            }
        }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public void GetTasks(int userId)
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
    
    public void CreateTask(CreateTask createTaskRequest)
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

    public void UpdateTask(UpdateTask updateTaskRequest)
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

    public void DeleteTask(DeleteTask deleteTaskRequest)
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
}