using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    public record GetAllStore():IRequest<List<Store>?>;

    public class GetAllStoreHandler(IStoreRepository storeRepository) : IRequestHandler<GetAllStore, List<Store>?>
    {
        public async Task<List<Store>?> Handle(GetAllStore request, CancellationToken cancellationToken)
        {
            return await storeRepository.GetAllStoresAsync();
        }
    }
}
