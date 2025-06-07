using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveLocationDataAsync(List<Province> provinces, CancellationToken cancellationToken)
        {
            _context.Provinces.RemoveRange(_context.Provinces);
            _context.Districts.RemoveRange(_context.Districts);
            _context.Wards.RemoveRange(_context.Wards);

            await _context.AddRangeAsync(provinces, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
