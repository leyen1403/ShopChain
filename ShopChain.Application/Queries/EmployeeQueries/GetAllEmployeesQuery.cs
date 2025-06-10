using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query để lấy toàn bộ danh sách nhân viên
    /// </summary>
    public record GetAllEmployeesQuery() : IRequest<List<Employee>>;

    /// <summary>
    /// Handler xử lý GetAllEmployeesQuery
    /// </summary>
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }
    }
}
