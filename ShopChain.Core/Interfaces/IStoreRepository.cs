using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store?> AddStoreAsync(Store store);
        Task<bool> DeleteStoreAsync(int id);
        Task<List<Store>> GetAllStoresAsync();
        Task<Store?> GetStoreByIdAsync(int id);
        Task<Store?> UpdateStoreAsync(Store store);
    }
}
