using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries.ProvinceQueries
{
    public record GetAllWardByDistrictNameQuery(string DistrictName) : IRequest<List<string>>;

    public class GetAllWardByDistrictNameQueryHandler : IRequestHandler<GetAllWardByDistrictNameQuery, List<string>>
    {
        private readonly IProvinceRepository _provinceRepository;
        public GetAllWardByDistrictNameQueryHandler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
        }
        public async Task<List<string>> Handle(GetAllWardByDistrictNameQuery request, CancellationToken cancellationToken)
        {
            return await _provinceRepository.GetAllWardByDistrictName(request.DistrictName);
        }
    }
}
