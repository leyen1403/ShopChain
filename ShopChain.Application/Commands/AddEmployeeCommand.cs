using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    /// <summary>
    /// Command để thêm mới một nhân viên
    /// </summary>
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee?>;

    /// <summary>
    /// Xử lý thêm mới nhân viên vào hệ thống
    /// </summary>
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employee?> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Employee == null)
            {
                return null;
            }

            return await _employeeRepository.AddEmployeeAsync(request.Employee);
        }
    }
}
