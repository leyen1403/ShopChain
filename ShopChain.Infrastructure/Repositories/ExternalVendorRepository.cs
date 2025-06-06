using ShopChain.Core.Interfaces;
using ShopChain.Core.Models;
using ShopChain.Infrastructure.Services;

namespace ShopChain.Infrastructure.Repositories
{
    /// <summary>
    /// Repository gọi external API để lấy dữ liệu 
    /// </summary>
    public class ExternalVendorRepository : IExternalVendorRepository
    {
        private readonly IProvinceHttpClientService _provinceHttpClientService;

        public ExternalVendorRepository(IProvinceHttpClientService provinceHttpClientService)
        {
            _provinceHttpClientService = provinceHttpClientService ?? throw new ArgumentNullException(nameof(provinceHttpClientService));
        }

        /// <summary>
        /// Gọi API để lấy danh sách tỉnh/thành phố từ bên ngoài
        /// </summary>
        public async Task<List<Province>> GetProvincesAsync()
        {
            return await _provinceHttpClientService.GetProvincesAsync();
        }
    }
}
