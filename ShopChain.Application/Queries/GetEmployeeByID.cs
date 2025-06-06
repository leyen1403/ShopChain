using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    public record GetEmployeeByID(int Id) : IRequest<Employee?>;

    public class GetEmployeeByIDHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByID, Employee?>
    {
        public async Task<Employee?> Handle(GetEmployeeByID request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
