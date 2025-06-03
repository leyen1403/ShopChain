using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Models
{
    public class Province
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public string CodeName { get; set; } = null!;
        public string DivisionType { get; set; } = null!;
        public int PhoneCode { get; set; }
        public List<District> Districts { get; set; } = null!;
    }

    public class District
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public string CodeName { get; set; } = null!;
        public string DivisionType { get; set; } = null!;
        public string ShortCodeName { get; set; } = null!;
        public List<Ward> Wards { get; set; } = null!;
    }

    public class Ward
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public string CodeName { get; set; } = null!;
        public string DivisionType { get; set; } = null!;
        public string ShortCodeName { get; set; } = null!;
    }
}
