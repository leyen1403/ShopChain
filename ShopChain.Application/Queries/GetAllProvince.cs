using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Core.Interfaces;
using ShopChain.Core.Models;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query gọi API bên ngoài để lấy danh sách tỉnh/thành
    /// </summary>
    public record GetAllProvince() : IRequest<List<Province>>;

    /// <summary>
    /// Handler xử lý GetAllProvince
    /// </summary>
    public class GetAllProvinceHandler : IRequestHandler<GetAllProvince, List<Province>>
    {
        private readonly IExternalVendorRepository _externalVendorRepository;

        public GetAllProvinceHandler(IExternalVendorRepository externalVendorRepository)
        {
            _externalVendorRepository = externalVendorRepository ?? throw new ArgumentNullException(nameof(externalVendorRepository));
        }

        public async Task<List<Province>> Handle(GetAllProvince request, CancellationToken cancellationToken)
        {
            return await _externalVendorRepository.GetProvincesAsync();
        }
    }
}
