using ShopChain.Core.Interfaces;
using ShopChain.Core.Models;
using ShopChain.Infrastructure.Services;

namespace ShopChain.Infrastructure.Repositories
{
    public class ExternalVendorRepository(ProvinceHttpClientService provinceHttpClientService) : IExternalVendorRepository
    {
        public async Task<List<Province>> GetProvincesAsync()
        {
            return await provinceHttpClientService.GetProvincesAsync();
        }
    }
}
