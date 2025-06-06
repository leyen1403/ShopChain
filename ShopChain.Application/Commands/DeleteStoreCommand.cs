using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    /// <summary>
    /// Command để xóa mềm một cửa hàng theo ID
    /// </summary>
    public record DeleteStoreCommand(int Id) : IRequest<bool>;

    /// <summary>
    /// Handler thực thi logic xóa mềm cửa hàng
    /// </summary>
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, bool>
    {
        private readonly IStoreRepository _storeRepository;

        public DeleteStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<bool> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            return await _storeRepository.DeleteStoreAsync(request.Id);
        }
    }
}
