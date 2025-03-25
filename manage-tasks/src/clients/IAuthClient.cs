using manage_tasks.src.models;

namespace manage_tasks.src.clients
{
    public interface IAuthClient
    { 
        public Task<TokenResponse> GetBearerToken();
    }
}