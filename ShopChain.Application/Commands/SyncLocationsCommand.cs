using ShopChain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands
{
    public record SyncLocationsCommand() : MediatR.IRequest<int>;

    public class SyncLocationsCommandHandler : MediatR.IRequestHandler<SyncLocationsCommand, int>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IVnAddressApiService _vnAddressApiService;

        public SyncLocationsCommandHandler(ILocationRepository locationRepository, IVnAddressApiService vnAddressApiService)
        {
            _locationRepository = locationRepository;
            _vnAddressApiService = vnAddressApiService;
        }

        public async Task<int> Handle(SyncLocationsCommand request, CancellationToken cancellationToken)
        {
            var provinces = await _vnAddressApiService.GetAllVnAddressAsync(cancellationToken);

            if (provinces == null || !provinces.Any())
            {
                return 0; // Không có dữ liệu để đồng bộ
            }

            await _locationRepository.SaveLocationDataAsync(provinces, cancellationToken);

            return provinces.Count;

        }
    }
}
