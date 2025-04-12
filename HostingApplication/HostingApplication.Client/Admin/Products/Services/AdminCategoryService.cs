using HostingApplication.Client.Models;
using System.Net.Http.Json;

namespace HostingApplication.Client.Admin.Products.Services
{

    public class AdminCategoryService
    {
        private readonly HttpClient _http;

        public AdminCategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CategoryDto>>("api/admin/categories") ?? new List<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<CategoryDto>($"api/admin/categories/{id}");
        }

        public async Task<bool> CreateCategoryAsync(CategoryDto category)
        {
            var response = await _http.PostAsJsonAsync("api/admin/categories", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto category)
        {
            var response = await _http.PutAsJsonAsync($"api/admin/categories/{category.Id}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/categories/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
