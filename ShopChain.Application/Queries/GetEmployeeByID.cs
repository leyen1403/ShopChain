using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query để lấy thông tin nhân viên theo ID
    /// </summary>
    public record GetEmployeeByIdQuery(int Id) : IRequest<Employee?>;

    /// <summary>
    /// Handler xử lý GetEmployeeByIdQuery
    /// </summary>
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
