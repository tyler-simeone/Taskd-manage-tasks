namespace manage_tasks.src.models
{
    public class Task : ResponseBase
    {
        public Task()
        {

        }

        public int TaskId { get; set; }
        
        public int ColumnId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public DateTime CreateDatetime { get; set; }

        public int CreateUserId { get; set; }

        public DateTime UpdateDatetime { get; set; }

        public int UpdateUserId { get; set; }
    }
}