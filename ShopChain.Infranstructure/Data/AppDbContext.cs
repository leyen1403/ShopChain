using Microsoft.EntityFrameworkCore;

namespace ShopChain.Infranstructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Core.Entities.Store> Stores { get; set; } = null!;
    }
}
