using System.Collections.Generic;
using System.Threading.Tasks;
using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    /// <summary>
    /// Interface định nghĩa các thao tác CRUD với nhân viên
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Nhân viên đã thêm hoặc null nếu thất bại</returns>
        Task<Employee?> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên cần cập nhật</param>
        /// <returns>Nhân viên sau khi cập nhật hoặc null nếu không tồn tại</returns>
        Task<Employee?> UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Xóa mềm nhân viên theo ID
        /// </summary>
        /// <param name="id">ID nhân viên</param>
        /// <returns>true nếu xóa thành công, ngược lại false</returns>
        Task<bool> DeleteEmployeeAsync(int id);

        /// <summary>
        /// Lấy thông tin nhân viên theo ID
        /// </summary>
        /// <param name="id">ID nhân viên</param>
        /// <returns>Nhân viên nếu tồn tại, ngược lại null</returns>
        Task<Employee?> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Lấy danh sách tất cả nhân viên chưa bị xóa
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
