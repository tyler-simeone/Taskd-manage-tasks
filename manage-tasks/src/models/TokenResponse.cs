namespace manage_tasks.src.models
{
    public class TokenResponse : ResponseBase
    {
        public TokenResponse() 
        {
            
        }

        public string AccessToken { get; set; }

        public string TokenType { get; set; }
        
        public int ExpiresIn { get; set; }
    }
}