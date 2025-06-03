using ShopChain.Core.Interfaces;
using ShopChain.Core.Models;
using ShopChain.Infranstructure.Services;

namespace ShopChain.Infranstructure.Repositories
{
    public class ExternalVendorRepository(ProvinceHttpClientService provinceHttpClientService) : IExternalVendorRepository
    {
        public async Task<List<Province>> GetProvincesAsync()
        {
            return await provinceHttpClientService.GetProvincesAsync();
        }
    }
}
