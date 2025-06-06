using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;

namespace ShopChain.Infrastructure.Data
{
    /// <summary>
    /// DbContext chính dùng để truy cập database
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Bảng cửa hàng
        /// </summary>
        public DbSet<Store> Stores { get; set; } = null!;

        /// <summary>
        /// Bảng nhân viên
        /// </summary>
        public DbSet<Employee> Employees { get; set; } = null!;

        /// <summary>
        /// Bảng phường/xã
        /// </summary>
        public DbSet<Ward> Wards { get; set; } = null!;

        /// <summary>
        /// Bảng quận/huyện
        /// </summary>
        public DbSet<District> Districts { get; set; } = null!;

        /// <summary>
        /// Bảng tỉnh/thành
        /// </summary>
        public DbSet<Province> Provinces { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Có thể cấu hình Fluent API tại đây nếu cần
            // modelBuilder.Entity<Store>().HasIndex(s => s.StoreCode).IsUnique();
        }
    }
}
