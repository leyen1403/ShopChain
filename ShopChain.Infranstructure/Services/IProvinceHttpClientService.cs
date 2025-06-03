using ShopChain.Core.Models;

namespace ShopChain.Infranstructure.Services
{
    public interface IProvinceHttpClientService
    {
        Task<List<Province>> GetProvincesAsync();
    }
}