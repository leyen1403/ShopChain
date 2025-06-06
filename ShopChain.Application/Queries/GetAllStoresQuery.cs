using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query để lấy toàn bộ danh sách cửa hàng
    /// </summary>
    public record GetAllStoresQuery() : IRequest<List<Store>>;

    /// <summary>
    /// Handler xử lý GetAllStoresQuery
    /// </summary>
    public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<Store>>
    {
        private readonly IStoreRepository _storeRepository;

        public GetAllStoresQueryHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<List<Store>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            return await _storeRepository.GetAllStoresAsync();
        }
    }
}
