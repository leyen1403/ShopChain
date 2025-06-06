using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
    {
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await context.Employees
                .Where(e => e.EmployeeID == id && !e.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Employee?> AddEmployeeAsync(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null || employee.IsDeleted)
            {
                return false;
            }
            employee.IsDeleted = true;
            employee.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
