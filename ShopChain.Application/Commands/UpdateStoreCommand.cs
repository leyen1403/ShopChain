using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record UpdateStoreCommand(Store Store) : IRequest<Store?>;

    public class UpdateStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<UpdateStoreCommand, Store?>
    {
        public async Task<Store?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            return await storeRepository.UpdateStoreAsync(request.Store);
        }
    }
}
