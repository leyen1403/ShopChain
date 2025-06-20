using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByID(int id);
    }
}
