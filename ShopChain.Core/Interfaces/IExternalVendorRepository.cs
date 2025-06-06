using ShopChain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopChain.Core.Interfaces
{
    /// <summary>
    /// Giao tiếp với dịch vụ bên ngoài để lấy dữ liệu 
    /// </summary>
    public interface IExternalVendorRepository
    {
        /// <summary>
        /// Lấy danh sách tỉnh/thành từ API bên ngoài
        /// </summary>
        /// <returns>Danh sách tỉnh/thành, trả về danh sách rỗng nếu thất bại</returns>
        Task<List<Province>> GetProvincesAsync();
    }
}
