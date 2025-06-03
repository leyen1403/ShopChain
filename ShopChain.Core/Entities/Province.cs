using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    public class Province
    {
        [Key]
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? CodeName { get; set; }
        public string? DivisionType { get; set; }
        public int PhoneCode { get; set; }
        public List<District> Districts { get; set; }
    }
}
