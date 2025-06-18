using ShopChain.Core.Entities;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
