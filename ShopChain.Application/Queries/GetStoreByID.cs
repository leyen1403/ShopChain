using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    public record GetStoreByID(int Id) : IRequest<Store?>;

    public class GetStoreByIDHandler(IStoreRepository storeRepository) : IRequestHandler<GetStoreByID, Store?>
    {
        public async Task<Store?> Handle(GetStoreByID request, CancellationToken cancellationToken)
        {
            return await storeRepository.GetStoreByIdAsync(request.Id);
        }
    }
}
