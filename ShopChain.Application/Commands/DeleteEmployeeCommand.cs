using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record DeleteEmployeeCommand(int Id) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
