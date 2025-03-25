namespace manage_tasks.src.models
{
    public class TaskTag : ResponseBase
    {
        public TaskTag()
        {
        }

        public int TaskTagId { get; set; }
       
        public int TagId { get; set; }
        
        public int TaskId { get; set; }
        
        public int BoardId { get; set; }
        
        public string TagName { get; set; }

        public DateTime CreateDatetime { get; set; }

        public int CreateUserId { get; set; }

        public DateTime? UpdateDatetime { get; set; }

        public int? UpdateUserId { get; set; }
    }
}