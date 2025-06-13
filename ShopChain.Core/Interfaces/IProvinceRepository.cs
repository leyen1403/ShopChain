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

        /// <summary>
        /// Lấy danh sách tên tỉnh có trong hệ thống
        /// </summary>
        /// <returns>Danh sách tên tỉnh</returns>
        Task<List<string?>> GetAllProvinceNames();

        /// <summary>
        /// Lấy danh sách tên quận/huyện theo tên tỉnh
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns>Danh sách tên quận/huyện</returns>
        Task<List<string?>> GetAllDistrictByProvinceName(string provinceName);

        /// <summary>
        /// Lấy danh sách tên phường/xã theo tên quận/huyện
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns>Danh sách tên phường/xã</returns>
        Task<List<string?>> GetAllWardByDistrictName(string districtName);
    }
}
