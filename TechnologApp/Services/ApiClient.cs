using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TechnologApp.Services
{
    public static class ApiClient
    {
        private static readonly HttpClient _httpClient;
        private static string? _token;

        static ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5057")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient Instance => _httpClient;

        public static void SetToken(string token)
        {
            _token = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static void ClearToken()
        {
            _token = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        // Для обратной совместимости с Create()
        public static HttpClient Create() => _httpClient;
    }

}