using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Infrastructure.ExternalServices.VnAddressServices.Dtos
{
    public class WardResponse
    {
        public string Name { get; set; } = string.Empty;

        public int Code { get; set; }

        public string CodeName { get; set; } = string.Empty;

        public string DivisionType { get; set; } = string.Empty;

        public string ShortCodeName { get; set; } = string.Empty;
    }
}
