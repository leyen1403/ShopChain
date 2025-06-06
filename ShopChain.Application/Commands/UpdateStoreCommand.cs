using System;
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
    /// Command cập nhật thông tin cửa hàng (từ StoreDto)
    /// </summary>
    public record UpdateStoreCommand(StoreDto StoreDto) : IRequest<StoreDto?>;

    /// <summary>
    /// Handler xử lý cập nhật cửa hàng
    /// </summary>
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, StoreDto?>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StoreDto?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            if (request.StoreDto == null)
                return null;

            var storeEntity = _mapper.Map<Store>(request.StoreDto);

            var updated = await _storeRepository.UpdateStoreAsync(storeEntity);

            return updated == null ? null : _mapper.Map<StoreDto>(updated);
        }
    }
}
