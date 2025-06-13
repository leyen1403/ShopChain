using MediatR;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries.ProvinceQueries
{
    public record GetAllProvinceName() : IRequest<List<string?>>; // Query để lấy danh sách tên tỉnh đã lưu trong hệ thống

    public class GetAllProvinceNameHandler : IRequestHandler<GetAllProvinceName, List<string?>>
    {
        private readonly IProvinceRepository _provinceRepository;
        public GetAllProvinceNameHandler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
        }
        public async Task<List<string?>> Handle(GetAllProvinceName request, CancellationToken cancellationToken)
        {
            return await _provinceRepository.GetAllProvinceNames();
        }
    }
}
