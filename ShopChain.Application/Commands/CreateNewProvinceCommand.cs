using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Commands
{
    public record CreateNewProvinceCommand(List<Core.Models.Province> Provinces) : MediatR.IRequest<List<Core.Entities.Province>>;

    public class CreateNewProvinceCommandHandler(Core.Interfaces.IProvinceRepository provinceRepository) : MediatR.IRequestHandler<CreateNewProvinceCommand, List<Core.Entities.Province>>
    {
        public async Task<List<Core.Entities.Province>> Handle(CreateNewProvinceCommand request, CancellationToken cancellationToken)
        {
            return await provinceRepository.CreateNewProvince(request.Provinces);
        }
    }
}
