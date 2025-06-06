using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    public class StoreRepository(AppDbContext context) : IStoreRepository
    {
        // Lấy danh sách chưa bị xoá
        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await context.Stores
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        // Lấy chi tiết store chưa bị xoá
        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            return await context.Stores
                .Where(s => s.StoreID == id && !s.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Store?> AddStoreAsync(Store store)
        {
            await context.Stores.AddAsync(store);
            await context.SaveChangesAsync();
            return store;
        }

        public async Task<Store?> UpdateStoreAsync(Store store)
        {
            context.Stores.Update(store);
            await context.SaveChangesAsync();
            return store;
        }

        // Soft Delete
        public async Task<bool> DeleteStoreAsync(int id)
        {
            var store = await context.Stores.FindAsync(id);
            if (store == null || store.IsDeleted)
            {
                return false;
            }
            store.IsDeleted = true;
            store.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
    }

}
