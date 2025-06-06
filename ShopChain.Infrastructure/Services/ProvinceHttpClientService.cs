using ShopChain.Core.Models;
using System.Net.Http.Json;

namespace ShopChain.Infrastructure.Services
{
    public class ProvinceHttpClientService(HttpClient httpClient) : IProvinceHttpClientService
    {
        public async Task<List<Province>> GetProvincesAsync()
        {
            var response = await httpClient.GetAsync("?depth=3");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Province>>() ?? new List<Province>();
        }
    }
}
