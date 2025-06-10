using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    /// <summary>
    /// Command cập nhật thông tin một nhân viên
    /// </summary>
    public record UpdateEmployeeCommand(Employee Employee) : IRequest<Employee?>;

    /// <summary>
    /// Handler xử lý cập nhật nhân viên
    /// </summary>
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Employee?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Employee == null)
            {
                return null;
            }

            return await _employeeRepository.UpdateEmployeeAsync(request.Employee);
        }
    }
}
