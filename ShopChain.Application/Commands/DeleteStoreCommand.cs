using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record DeleteStoreCommand(int Id) : IRequest<bool>;

    public class DeleteStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<DeleteStoreCommand, bool>
    {
        public async Task<bool> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            return await storeRepository.DeleteStoreAsync(request.Id);
        }
    }
}
