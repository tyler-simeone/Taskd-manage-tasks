public class CreateTask
{
    public CreateTask()
    {
        
    }

    public int UserId { get; set; }

    public int ColumnId { get; set; }
    
    public int BoardId { get; set; }
    
    public int? TagId { get; set; }

    public string TaskName { get; set; }

    public string TaskDescription { get; set; }
}