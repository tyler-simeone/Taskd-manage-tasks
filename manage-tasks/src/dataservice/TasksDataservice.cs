using System;
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
        using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"CALL ProjectB.TaskGetDetailsByTaskId(@paramTaskId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@paramTaskId", taskId);

                    try
                    {
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("TaskId"); 
                                string name = reader.GetString("TaskName"); 

                                Console.WriteLine($"ID: {id}, Name: {name}");
                            }
                        }
                        }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
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