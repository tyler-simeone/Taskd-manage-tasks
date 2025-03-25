using System.Net.Http.Headers;
using manage_tasks.src.models;
using manage_tasks.src.models.requests;
using Microsoft.IdentityModel.Tokens;

namespace manage_tasks.src.clients
{
    public class TagsClient : ITagsClient
    {
        private IConfiguration _configuration;
        private readonly HttpClient _client;
        private readonly IAuthClient _authClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TagsClient(IConfiguration configuration,
                             IAuthClient authClient,
                             IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;

            var conx = _configuration["ManageColumnsLocalConnection"];
            if (conx.IsNullOrEmpty())
                conx = _configuration.GetConnectionString("ManageColumnsLocalConnection");

            _client = new HttpClient
            {
                BaseAddress = new Uri(conx)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _authClient = authClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> AddTagToTask(int userId, int boardId, int tagId, int taskId)
        {
            var bearerToken = new TokenResponse();

            // check for existing auth token in request and reuse that instead of generating new...
            var context = _httpContextAccessor.HttpContext;
            var authHeader = context.Request.Headers["Authorization"].ToString();

            // if we're at this point then client should have auth token...
            if (authHeader == string.Empty)
                bearerToken = await _authClient.GetBearerToken();
            else
            {
                if (authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    authHeader = authHeader["Bearer ".Length..].Trim();
                bearerToken.AccessToken = authHeader;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken.AccessToken);

            var payload = new AddTagToTask(userId, boardId, tagId, taskId);

            var response = await _client.PostAsJsonAsync($"/api/Tags/Task", payload);

            if (response.IsSuccessStatusCode)
            {
                var newTagId = await response.Content.ReadFromJsonAsync<int>();
                return newTagId;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}