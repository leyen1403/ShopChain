using ShopChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Interfaces
{
    public interface IExternalVendorRepository
    {
        Task<List<Province>> GetProvincesAsync();
    }
}
