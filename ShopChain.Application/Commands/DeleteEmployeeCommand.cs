using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    /// <summary>
    /// Command để xóa mềm một nhân viên theo ID
    /// </summary>
    public record DeleteEmployeeCommand(int Id) : IRequest<bool>;

    /// <summary>
    /// Xử lý command xóa nhân viên
    /// </summary>
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
