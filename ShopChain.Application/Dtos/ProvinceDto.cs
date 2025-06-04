using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Dtos
{
    public class ProvinceDto
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public string CodeName { get; set; } = null!;
        public string DivisionType { get; set; } = null!;
        public int PhoneCode { get; set; }
        public List<DistrictDto> Districts { get; set; } = null!;
    }
}
