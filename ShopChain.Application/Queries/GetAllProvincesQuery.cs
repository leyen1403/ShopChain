using MediatR;
using ShopChain.Application.Dtos;
using ShopChain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Queries
{
    public record GetAllProvincesQuery() : IRequest<List<ProvinceDto>>;

    public class GetAllProvincesQueryHandler(IProvinceRepository provinceRepository) : IRequestHandler<GetAllProvincesQuery, List<ProvinceDto>>
    {
        public async Task<List<ProvinceDto>> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
        {
            var entity = await provinceRepository.GetAllProvinces();

            var dto = entity.Select(e => new ProvinceDto()
            {
                Name = e.Name,
                Code = e.Code,
                CodeName = e.CodeName,
                DivisionType = e.DivisionType,
                PhoneCode = e.PhoneCode,
                Districts = e.Districts.Select(p=> new DistrictDto()
                {
                    Name = p.Name,
                    Code = p.Code,
                    CodeName = p.CodeName,
                    DivisionType = p.DivisionType,
                    ShortCodeName = p.ShortCodeName,
                    Wards = p.Wards.Select(d=>new WardDto()
                    {
                        Name = d.Name,
                        Code = d.Code,
                        CodeName = d.CodeName,
                        DivisionType = d.DivisionType,
                        ShortCodeName = d.ShortCodeName
                    }).ToList()
                }).ToList()
            }).ToList();

            return dto;
        }
    }
}
