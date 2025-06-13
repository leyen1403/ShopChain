using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopChain.Application.Dtos;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Queries
{
    /// <summary>
    /// Query để lấy danh sách tỉnh đã lưu trong hệ thống (bao gồm quận/huyện, phường/xã)
    /// </summary>
    public record GetAllProvincesQuery() : IRequest<List<ProvinceDto>>;

    /// <summary>
    /// Handler xử lý GetAllProvincesQuery
    /// </summary>
    public class GetAllProvincesQueryHandler : IRequestHandler<GetAllProvincesQuery, List<ProvinceDto>>
    {
        private readonly IProvinceRepository _provinceRepository;

        public GetAllProvincesQueryHandler(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
        }

        public async Task<List<ProvinceDto>> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
        {
            var provinces = await _provinceRepository.GetAllProvinces();

            return provinces.Select(p => new ProvinceDto
            {
                Name = p.Name,
                Code = p.Code,
                CodeName = p.CodeName,
                DivisionType = p.DivisionType,
                PhoneCode = p.PhoneCode,
                Districts = p.Districts.Select(d => new DistrictDto
                {
                    Name = d.Name,
                    Code = d.Code,
                    CodeName = d.CodeName,
                    DivisionType = d.DivisionType,
                    ShortCodeName = d.ShortCodeName,
                    Wards = d.Wards.Select(w => new WardDto
                    {
                        Name = w.Name,
                        Code = w.Code,
                        CodeName = w.CodeName,
                        DivisionType = w.DivisionType,
                        ShortCodeName = w.ShortCodeName
                    }).ToList()
                }).ToList()
            }).ToList();
        }
    }
}
