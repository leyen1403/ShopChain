using System.Collections.Generic;
using System.Threading.Tasks;
using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    /// <summary>
    /// Interface quản lý thao tác CRUD với cửa hàng
    /// </summary>
    public interface IStoreRepository
    {
        /// <summary>
        /// Thêm mới một cửa hàng
        /// </summary>
        /// <param name="store">Thông tin cửa hàng</param>
        /// <returns>Cửa hàng sau khi thêm</returns>
        Task<Store?> AddStoreAsync(Store store);

        /// <summary>
        /// Cập nhật thông tin cửa hàng
        /// </summary>
        /// <param name="store">Cửa hàng cần cập nhật</param>
        /// <returns>Cửa hàng sau khi cập nhật</returns>
        Task<Store?> UpdateStoreAsync(Store store);

        /// <summary>
        /// Xóa mềm cửa hàng theo ID
        /// </summary>
        /// <param name="id">ID cửa hàng</param>
        /// <returns>true nếu xóa thành công, ngược lại false</returns>
        Task<bool> DeleteStoreAsync(int id);

        /// <summary>
        /// Lấy danh sách tất cả cửa hàng chưa bị xóa
        /// </summary>
        /// <returns>Danh sách cửa hàng</returns>
        Task<List<Store>> GetAllStoresAsync();

        /// <summary>
        /// Lấy thông tin cửa hàng theo ID
        /// </summary>
        /// <param name="id">ID cửa hàng</param>
        /// <returns>Cửa hàng nếu tồn tại, null nếu không tìm thấy</returns>
        Task<Store?> GetStoreByIdAsync(int id);
    }
}
