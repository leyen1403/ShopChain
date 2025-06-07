using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Infrastructure.ExternalServices.VnAddressServices.Dtos
{
    public class ProvinceResponse
    {
        public string Name { get; set; } = string.Empty;

        public int Code { get; set; }

        public string CodeName { get; set; } = string.Empty;

        public string DivisionType { get; set; } = string.Empty;

        public int PhoneCode { get; set; }

        public List<DistrictResponse> Districts { get; set; } = new();
    }
}
