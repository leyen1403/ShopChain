using Microsoft.EntityFrameworkCore;

namespace ShopChain.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Core.Entities.Store> Stores { get; set; } = null!;
        public DbSet<Core.Entities.Employee> Employees { get; set; } = null!;
        public DbSet<Core.Entities.Ward> Wards { get; set; } = null!;
        public DbSet<Core.Entities.District> Districts { get; set; } = null!;
        public DbSet<Core.Entities.Province> Provinces { get; set; } = null!;
    }
}
