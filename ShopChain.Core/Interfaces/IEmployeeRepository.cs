using ShopChain.Core.Entities;

namespace ShopChain.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> AddEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
