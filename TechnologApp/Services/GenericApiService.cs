using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechnologApp.Services
{
    public class GenericApiService<T> where T : class
    {
        private readonly HttpClient _http;
        private readonly string _endpoint;

        public GenericApiService(HttpClient http, string endpoint)
        {
            _http = http;
            _endpoint = endpoint;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var response = await _http.GetAsync($"/api/{_endpoint}");
            if (!response.IsSuccessStatusCode) return new List<T>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await _http.GetAsync($"/api/{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<bool> CreateAsync(T entity)
        {
            var json = JsonSerializer.Serialize(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(_endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            var json = JsonSerializer.Serialize(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PutAsync($"/api/{_endpoint}/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"/api/{_endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}