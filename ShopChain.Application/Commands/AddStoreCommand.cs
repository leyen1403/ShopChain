using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record AddStoreCommand(Store Store) : IRequest<Store?>;

    public class AddStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<AddStoreCommand, Store?>
    {
        public async Task<Store?> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            return await storeRepository.AddStoreAsync(request.Store);
        }
    }
}