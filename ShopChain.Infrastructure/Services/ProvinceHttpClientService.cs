using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ShopChain.Core.Models;

namespace ShopChain.Infrastructure.Services
{
    /// <summary>
    /// Service gọi API lấy danh sách tỉnh từ nguồn ngoài
    /// </summary>
    public class ProvinceHttpClientService : IProvinceHttpClientService
    {
        private readonly HttpClient _httpClient;

        public ProvinceHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Gọi API lấy danh sách tỉnh với độ sâu = 3
        /// </summary>
        public async Task<List<Province>> GetProvincesAsync()
        {
            var response = await _httpClient.GetAsync("?depth=3");

            // Đảm bảo không bị lỗi nếu status code không thành công
            response.EnsureSuccessStatusCode();

            // Tránh lỗi null nếu API không trả về danh sách
            var provinces = await response.Content.ReadFromJsonAsync<List<Province>>();
            return provinces ?? new List<Province>();
        }
    }
}
