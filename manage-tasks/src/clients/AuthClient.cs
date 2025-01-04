using System.Net.Http.Headers;
using System.Text.Json;
using manage_tasks.src.models;
using Microsoft.IdentityModel.Tokens;

namespace manage_tasks.src.clients
{
    public class AuthClient : IAuthClient
    {
        private IConfiguration _configuration;
        private readonly HttpClient _client;

        public AuthClient(IConfiguration configuration)
        {
            _configuration = configuration;

            var conx = _configuration["ManageAuthLocalConnection"];
            if (conx.IsNullOrEmpty())
                conx = _configuration.GetConnectionString("ManageAuthLocalConnection");
            
            _client = new HttpClient
            {
                BaseAddress = new Uri(conx)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TokenResponse> GetBearerToken()
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/Auth/");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseBody);
                return tokenResponse;
            }
            else 
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}