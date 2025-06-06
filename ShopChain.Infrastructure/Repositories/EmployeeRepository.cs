using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    /// <summary>
    /// Repository xử lý nghiệp vụ liên quan đến nhân viên
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Lấy tất cả nhân viên chưa bị xóa mềm
        /// </summary>
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo ID (chỉ khi chưa bị xóa)
        /// </summary>
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Where(e => e.EmployeeID == id && !e.IsDeleted)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        public async Task<Employee?> AddEmployeeAsync(Employee employee)
        {
            if (employee is null) return null;

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            if (employee is null) return null;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        /// <summary>
        /// Xóa mềm nhân viên theo ID
        /// </summary>
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee?.IsDeleted != false)
            {
                return false;
            }

            employee.IsDeleted = true;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
