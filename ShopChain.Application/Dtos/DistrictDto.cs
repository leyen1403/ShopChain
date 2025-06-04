using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Dtos
{
    public class DistrictDto
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public string CodeName { get; set; } = null!;
        public string DivisionType { get; set; } = null!;
        public string ShortCodeName { get; set; } = null!;
        public List<WardDto> Wards { get; set; } = null!;
    }
}
