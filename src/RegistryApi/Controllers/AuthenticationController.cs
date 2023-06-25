using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;

namespace RegistryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHttpService _httpService;
        public AuthenticationController(IHttpService httpService)
        {
            _httpService = httpService;
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            var authorizationKey = Environment.GetEnvironmentVariable("AUTHORIZATION_KEY");

            if (!HttpContext.Request.Headers.TryGetValue("authorizationKey", out var authorizationKeyRequest))
            {
                authorizationKeyRequest = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(authorizationKeyRequest))
            {
                return Unauthorized();
            }

            if (!authorizationKey?.Equals(authorizationKeyRequest) ?? false)
            {
                return Forbid();
            }
            
            var path = $"{Environment.GetEnvironmentVariable("AUTH0_AUTHORITY")}oauth/token";
            
            var body = new
            {
                client_id = Environment.GetEnvironmentVariable("AUTH0_CLIENT_ID"),
                client_secret = Environment.GetEnvironmentVariable("AUTH0_CLIENT_SECRET"),
                audience = Environment.GetEnvironmentVariable("AUTH0_AUDIENCE"),
                grant_type = "client_credentials"
            };

            var result = _httpService.PostSync(path, JsonSerializer.Serialize(body));

            var response = await result.Content.ReadAsStringAsync();
            
            return Ok(response);
        }
    }
}
