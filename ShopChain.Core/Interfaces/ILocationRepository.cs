using ShopChain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Interfaces
{
    public interface ILocationRepository
    {
        Task SaveLocationDataAsync(List<Province> provinces, CancellationToken cancellationToken);
    }
}
