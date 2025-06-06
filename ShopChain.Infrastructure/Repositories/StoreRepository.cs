using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    /// <summary>
    /// Repository thao tác với bảng cửa hàng (Store)
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Lấy danh sách cửa hàng chưa bị xóa
        /// </summary>
        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _context.Stores
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy thông tin cửa hàng theo ID (chưa bị xóa)
        /// </summary>
        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            return await _context.Stores
                .Where(s => s.StoreID == id && !s.IsDeleted)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        public async Task<Store?> AddStoreAsync(Store store)
        {
            if (store == null)
            {
                return null;
            }

            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        /// <summary>
        /// Cập nhật thông tin cửa hàng
        /// </summary>
        public async Task<Store?> UpdateStoreAsync(Store store)
        {
            if (store == null)
            {
                return null;
            }

            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
            return store;
        }

        /// <summary>
        /// Xóa mềm cửa hàng theo ID
        /// </summary>
        public async Task<bool> DeleteStoreAsync(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null || store.IsDeleted)
            {
                return false;
            }

            store.IsDeleted = true;
            store.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
