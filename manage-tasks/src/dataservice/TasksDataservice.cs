using System;
using System.Data;
using manage_tasks.src.models;
using manage_tasks.src.models.requests;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace manage_tasks.src.dataservice
{
    public class TasksDataservice : ITasksDataservice
    {
        private IConfiguration _configuration;
        private string _conx;

        public TasksDataservice(IConfiguration configuration)
        {
            _configuration = configuration;
            _conx = _configuration["LocalDBConnection"];

            if (_conx.IsNullOrEmpty())
                _conx = _configuration.GetConnectionString("LocalDBConnection");
        }

        public async Task<models.Task> GetTask(int taskId, int userId)
        {
            using (MySqlConnection connection = new(_conx))
            {
                using (MySqlCommand command = new("taskd_db_dev.TaskGetDetailsByTaskId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@paramTaskId", taskId);

                    try
                    {
                        await connection.OpenAsync();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return ExtractTaskFromReader(reader);
                            }

                            return new models.Task();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task<TaskList> GetTasks(int columnId)
        {
            using MySqlConnection connection = new(_conx);
            using MySqlCommand command = new("taskd_db_dev.TaskGetAllByColumnId", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@paramColumnId", columnId);

            try
            {
                await connection.OpenAsync();

                using MySqlDataReader reader = command.ExecuteReader();
                
                var taskList = new TaskList();

                while (reader.Read())
                {
                    models.Task task = ExtractTaskFromReader(reader);
                    taskList.Tasks.Add(task);
                }

                return taskList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        
        public async Task<List<TaskTag>> GetTaskTags(int columnId, int boardId)
        {
            using MySqlConnection connection = new(_conx);
            using MySqlCommand command = new("taskd_db_dev.TaskTagGetAllByColumnIdAndBoardId", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@paramColumnId", columnId);
            command.Parameters.AddWithValue("@paramBoardId", boardId);

            try
            {
                await connection.OpenAsync();

                using MySqlDataReader reader = command.ExecuteReader();

                var tags = new List<TaskTag>();

                while (reader.Read())
                {
                    var tag = new TaskTag
                    {
                        TagId = reader.GetInt32("TagId"),
                        TaskTagId = reader.GetInt32("TaskTagId"),
                        TaskId = reader.GetInt32("TaskId"),
                        TagName = reader.GetString("TagName"),
                    };
                    tags.Add(tag);
                }

                return tags;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<int> CreateTask(CreateTask createTaskRequest)
        {
            using (MySqlConnection connection = new(_conx))
            {
                using (MySqlCommand command = new("taskd_db_dev.TaskPersist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@paramColumnId", createTaskRequest.ColumnId);
                    command.Parameters.AddWithValue("@paramTaskName", createTaskRequest.TaskName);
                    command.Parameters.AddWithValue("@paramTaskDescription", createTaskRequest.TaskDescription);
                    command.Parameters.AddWithValue("@paramCreateUserId", createTaskRequest.UserId);

                    try
                    {
                        await connection.OpenAsync();

                        int id = 0;

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader.GetInt32("TaskId");
                            }

                            return id;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async void UpdateTask(UpdateTask updateTaskRequest)
        {

            using (MySqlConnection connection = new(_conx))
            {
                using (MySqlCommand command = new("taskd_db_dev.TaskUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@paramTaskId", updateTaskRequest.TaskId);
                    command.Parameters.AddWithValue("@paramColumnId", updateTaskRequest.ColumnId);
                    command.Parameters.AddWithValue("@paramTaskName", updateTaskRequest.TaskName);
                    command.Parameters.AddWithValue("@paramTaskDescription", updateTaskRequest.TaskDescription);
                    command.Parameters.AddWithValue("@paramUpdateUserId", updateTaskRequest.UserId);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }
        
        public async void DropTask(DropTask dropTaskRequest)
        {

            using (MySqlConnection connection = new(_conx))
            {
                using (MySqlCommand command = new("taskd_db_dev.TaskDrop", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@paramUserId", dropTaskRequest.UserId);
                    command.Parameters.AddWithValue("@paramColumnId", dropTaskRequest.ColumnId);
                    command.Parameters.AddWithValue("@paramTaskId", dropTaskRequest.TaskId);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async void DeleteTask(int taskId, int userId)
        {
            using (MySqlConnection connection = new(_conx))
            {
                using (MySqlCommand command = new("taskd_db_dev.TaskDelete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@paramTaskId", taskId);
                    command.Parameters.AddWithValue("@paramUpdateUserId", userId);

                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        #region HELPERS

        private models.Task ExtractTaskFromReader(MySqlDataReader reader)
        {
            int id = reader.GetInt32("TaskId");
            int columnId = reader.GetInt32("ColumnId");
            
            int? boardId = null;
            try
            {
                boardId = reader.IsDBNull(reader.GetOrdinal("BoardId")) ? null : reader.GetInt32("BoardId");
            }
            catch
            {}

            string name = reader.GetString("TaskName");
            string description = reader.GetString("TaskDescription");
            DateTime createDatetime = reader.GetDateTime("CreateDatetime");
            int createUserId = reader.GetInt32("CreateUserId");
            DateTime? updateDatetime = reader.IsDBNull(reader.GetOrdinal("UpdateDatetime")) ? null : reader.GetDateTime("UpdateDatetime");
            int? updateUserId = reader.IsDBNull(reader.GetOrdinal("UpdateUserId")) ? null : reader.GetInt32("UpdateUserId");

            return new models.Task()
            {
                TaskId = id,
                ColumnId = columnId,
                BoardId = boardId,
                TaskName = name,
                TaskDescription = description,
                CreateDatetime = createDatetime,
                CreateUserId = createUserId,
                UpdateDatetime = updateDatetime,
                UpdateUserId = updateUserId
            };
        }

        #endregion
    }
}