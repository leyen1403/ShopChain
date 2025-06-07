using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    public interface IVnAddressApiService
    {
        Task<List<Province>> GetAllVnAddressAsync(CancellationToken cancellationToken = default);
    }
}
