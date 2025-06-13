using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries.ProvinceQueries
{
    public record GetAllDistrictByProvinceNameQuery(string ProvinceName) : IRequest<List<string>>;

    public class GetAllDistrictByProvinceNameQueryHandler : IRequestHandler<GetAllDistrictByProvinceNameQuery, List<string>>
    {
        private readonly IProvinceRepository _provinceRepository;
        public GetAllDistrictByProvinceNameQueryHandler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
        }
        public async Task<List<string?>> Handle(GetAllDistrictByProvinceNameQuery request, CancellationToken cancellationToken)
        {
            return await _provinceRepository.GetAllDistrictByProvinceName(request.ProvinceName);
        }
    }
}
