using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Interfaces
{
    public interface IProvinceRepository
    {
        Task<List<ShopChain.Core.Entities.Province>> CreateNewProvince(List<ShopChain.Core.Models.Province> provinces);

        Task<List<ShopChain.Core.Entities.Province>> GetAllProvinces();
    }
}
