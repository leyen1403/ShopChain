using ShopChain.Core.Models;

namespace ShopChain.Infrastructure.Services
{
    public interface IProvinceHttpClientService
    {
        Task<List<Province>> GetProvincesAsync();
    }
}