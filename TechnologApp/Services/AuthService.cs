using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechnologApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(string baseUrl)
        {
            _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<LoginResult?> LoginAsync(string username, string password)
        {
            var data = new { Login = username, PasswordHash = password };
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("/login/api/SignIn", content);
            if (!response.IsSuccessStatusCode) return null;

            var resultJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResult>(resultJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }

    public class LoginResult
    {
        public string access_token { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
    }
}