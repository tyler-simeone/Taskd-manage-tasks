namespace manage_tasks.src.models
{
    public class ListResponse<T>(List<T> data) : ResponseBase
    {
        public int Total 
        { 
            get { return Data.Count; }
        }
        
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public List<T> Data { get; set; } = data;
    }
}