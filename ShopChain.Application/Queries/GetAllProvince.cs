using MediatR;
using ShopChain.Core.Interfaces;
using ShopChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Queries
{
    public record GetAllProvince():IRequest<List<Province>>;

    public class GetAllProvinceHandler(IExternalVendorRepository externalVendorRepository) : IRequestHandler<GetAllProvince, List<Province>>
    {
        public async Task<List<Province>> Handle(GetAllProvince request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetProvincesAsync();
        }
    }
}
