using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infranstructure.Data;

namespace ShopChain.Infranstructure.Repositories
{
    public class FormatProvider(AppDbContext context) : IStoreRepository
    {
        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await context.Stores.ToListAsync();
        }

        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            return await context.Stores.FindAsync(id);
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

        public async Task<bool> DeleteStoreAsync(int id)
        {
            var store = await context.Stores.FindAsync(id);
            if (store == null)
            {
                return false;
            }
            context.Stores.Remove(store);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
