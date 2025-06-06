using System.Collections.Generic;
using System.Threading.Tasks;
using ShopChain.Core.Entities;
using ShopChain.Core.Models;

namespace ShopChain.Core.Interfaces
{
    /// <summary>
    /// Repository quản lý dữ liệu tỉnh/thành nội bộ hệ thống
    /// </summary>
    public interface IProvinceRepository
    {
        /// <summary>
        /// Thêm mới danh sách tỉnh/thành vào cơ sở dữ liệu nội bộ từ dữ liệu bên ngoài
        /// </summary>
        /// <param name="provinces">Danh sách tỉnh từ API bên ngoài</param>
        /// <returns>Danh sách tỉnh đã được thêm vào DB</returns>
        Task<List<Entities.Province>> CreateNewProvince(List<Models.Province> provinces);

        /// <summary>
        /// Lấy tất cả tỉnh/thành đã lưu trong hệ thống
        /// </summary>
        /// <returns>Danh sách tỉnh</returns>
        Task<List<Entities.Province>> GetAllProvinces();
    }
}
