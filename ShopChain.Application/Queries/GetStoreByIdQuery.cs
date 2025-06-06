using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query để lấy thông tin cửa hàng theo ID
    /// </summary>
    public record GetStoreByIdQuery(int Id) : IRequest<Store?>;

    /// <summary>
    /// Handler xử lý GetStoreByIdQuery
    /// </summary>
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, Store?>
    {
        private readonly IStoreRepository _storeRepository;

        public GetStoreByIdQueryHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<Store?> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _storeRepository.GetStoreByIdAsync(request.Id);
        }
    }
}
