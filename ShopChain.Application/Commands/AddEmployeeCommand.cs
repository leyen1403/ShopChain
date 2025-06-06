using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee?>;

    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommand, Employee?>
    {
        public async Task<Employee?> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddEmployeeAsync(request.Employee);
        }
    }
}
