using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopChain.Application.Dtos;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    /// <summary>
    /// Command để thêm mới cửa hàng từ StoreDto
    /// </summary>
    public record AddStoreCommand(StoreDto StoreDto) : IRequest<StoreDto?>;

    /// <summary>
    /// Handler xử lý việc thêm cửa hàng mới
    /// </summary>
    public class AddStoreCommandHandler : IRequestHandler<AddStoreCommand, StoreDto?>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public AddStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StoreDto?> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            if (request.StoreDto == null)
                return null;

            var entity = _mapper.Map<Store>(request.StoreDto);
            var result = await _storeRepository.AddStoreAsync(entity);

            return result is null ? null : _mapper.Map<StoreDto>(result);
        }
    }
}
