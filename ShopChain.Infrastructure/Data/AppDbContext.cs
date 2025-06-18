using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;

namespace ShopChain.Infrastructure.Data
{
    /// <summary>
    /// DbContext chính dùng để truy cập và cấu hình database.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ===== Quản lý cửa hàng =====
        /// <summary>Bảng cửa hàng</summary>
        // ===== Địa lý =====
        public DbSet<Store> Stores { get; set; } = null!;

        /// <summary>Bảng tỉnh/thành</summary>
        public DbSet<Province> Provinces { get; set; } = null!;

        /// <summary>Bảng quận/huyện</summary>
        public DbSet<District> Districts { get; set; } = null!;

        /// <summary>Bảng phường/xã</summary>
        public DbSet<Ward> Wards { get; set; } = null!;

        // ===== Nhân sự =====

        /// <summary>Bảng nhân viên</summary>
        public DbSet<Employee> Employees { get; set; } = null!;

        /// <summary>Bảng phòng ban</summary>
        public DbSet<Department> Departments { get; set; } = null!;

        /// <summary> Bảng khách hàng sử dụng ứng dụng </summary>
        public DbSet<UserClient> UserClients { get; set; }

        /// <summary> Bảng nhóm sản phẩm </summary>
        public DbSet<ProductGroup> ProductGroups { get; set; } = null!;

        /// <summary> Bảng sản phẩm </summary>
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === Quan hệ nhân viên - phòng ban ===
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa phòng ban nếu còn nhân viên

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerID)
                .OnDelete(DeleteBehavior.SetNull); // Nếu manager bị xóa thì set null           
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries<AuditableEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
