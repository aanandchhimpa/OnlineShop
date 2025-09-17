using HostingApplication.Client.Models;
using System.Net.Http.Json;

namespace HostingApplication.Client.Admin.Products.Services
{
    public class AdminBrandService
    {
        private readonly HttpClient _http;

        public AdminBrandService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BrandDto>> GetBrandsAsync()
        {
            return await _http.GetFromJsonAsync<List<BrandDto>>("api/admin/brands") ?? new List<BrandDto>();
        }

        public async Task<BrandDto?> GetBrandByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<BrandDto>($"api/admin/brands/{id}");
        }

        public async Task<bool> CreateBrandAsync(BrandDto brand)
        {
            var response = await _http.PostAsJsonAsync("api/admin/brands", brand);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBrandAsync(BrandDto brand)
        {
            var response = await _http.PutAsJsonAsync($"api/admin/brands/{brand.Id}", brand);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/brands/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
