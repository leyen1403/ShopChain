using System.Collections.Generic;
using System.Threading.Tasks;
using ShopChain.Core.Models;

namespace ShopChain.Infrastructure.Services
{
    /// <summary>
    /// Interface định nghĩa các phương thức gọi API tỉnh/thành từ hệ thống bên ngoài
    /// </summary>
    public interface IProvinceHttpClientService
    {
        /// <summary>
        /// Gọi API để lấy danh sách tỉnh/thành
        /// </summary>
        /// <returns>Danh sách Province từ hệ thống bên ngoài</returns>
        Task<List<Province>> GetProvincesAsync();
    }
}
