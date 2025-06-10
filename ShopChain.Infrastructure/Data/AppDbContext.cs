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

        // ===== Chấm công & Nghỉ phép =====

        /// <summary>Bảng chấm công</summary>
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; } = null!;

        /// <summary>Bảng yêu cầu nghỉ phép</summary>
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;

        /// <summary>Bảng loại nghỉ phép</summary>
        public DbSet<LeaveType> LeaveTypes { get; set; } = null!;

        // ===== Lương =====

        /// <summary>Bảng bảng lương</summary>
        public DbSet<PayrollRecord> PayrollRecords { get; set; } = null!;

        /// <summary>Bảng kỳ lương</summary>
        public DbSet<PayrollPeriod> PayrollPeriods { get; set; } = null!;

        // ===== Đánh giá hiệu suất =====

        /// <summary>Bảng đánh giá</summary>
        public DbSet<PerformanceReview> PerformanceReviews { get; set; } = null!;

        /// <summary>Bảng chu kỳ đánh giá</summary>
        public DbSet<PerformanceCycle> PerformanceCycles { get; set; } = null!;

        // ===== Tuyển dụng =====

        /// <summary>Bảng yêu cầu tuyển dụng</summary>
        public DbSet<JobRequest> JobRequests { get; set; } = null!;

        /// <summary>Bảng tin tuyển dụng</summary>
        public DbSet<JobPosting> JobPostings { get; set; } = null!;

        /// <summary>Bảng ứng viên</summary>
        public DbSet<Candidate> Candidates { get; set; } = null!;

        /// <summary>Bảng ứng tuyển</summary>
        public DbSet<JobApplication> JobApplications { get; set; } = null!;


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

            // === Quan hệ yêu cầu nghỉ phép ===
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany()
                .HasForeignKey(lr => lr.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Approver)
                .WithMany()
                .HasForeignKey(lr => lr.ApproverID)
                .OnDelete(DeleteBehavior.Restrict); // Tránh cascade lặp

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.LeaveType)
                .WithMany(lt => lt.LeaveRequests)
                .HasForeignKey(lr => lr.LeaveTypeID);

            // === Index chấm công: duy nhất theo nhân viên và ngày ===
            modelBuilder.Entity<AttendanceRecord>()
                .HasIndex(a => new { a.EmployeeID, a.Date })
                .IsUnique();

            // === Index lương: duy nhất theo nhân viên và kỳ lương ===
            modelBuilder.Entity<PayrollRecord>()
                .HasIndex(p => new { p.EmployeeID, p.PayrollPeriodID })
                .IsUnique();

            modelBuilder.Entity<PayrollPeriod>()
                .HasIndex(p => p.PeriodName)
                .IsUnique();

            // === Đánh giá hiệu suất ===
            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Manager)
                .WithMany()
                .HasForeignKey(pr => pr.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PerformanceCycle>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.PerformanceCycle)
                .HasForeignKey(r => r.PerformanceCycleID)
                .OnDelete(DeleteBehavior.Cascade);


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
