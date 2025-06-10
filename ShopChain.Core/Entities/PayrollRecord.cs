using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Trạng thái bản ghi lương
    /// </summary>
    public enum PayrollStatus
    {
        Calculated,
        Approved,
        Paid
    }

    /// <summary>
    /// Bản ghi tính lương của một nhân viên trong một kỳ lương
    /// </summary>
    public class PayrollRecord : AuditableEntity
    {
        /// <summary>ID bản ghi lương</summary>
        [Key]
        public int PayrollRecordID { get; set; }

        /// <summary>ID nhân viên</summary>
        public int EmployeeID { get; set; }

        /// <summary>Thông tin nhân viên</summary>
        public Employee Employee { get; set; } = null!;

        /// <summary>ID kỳ lương</summary>
        public int PayrollPeriodID { get; set; }

        /// <summary>Thông tin kỳ lương</summary>
        public PayrollPeriod PayrollPeriod { get; set; } = null!;

        // ===== Thông tin tính lương =====

        /// <summary>Lương cơ bản</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasicSalary { get; set; }

        /// <summary>Số ngày làm việc thực tế</summary>
        public int WorkDays { get; set; }

        /// <summary>Số ngày nghỉ có lương</summary>
        public int PaidLeaveDays { get; set; }

        /// <summary>Số ngày nghỉ không lương</summary>
        public int UnpaidLeaveDays { get; set; }

        /// <summary>Số giờ tăng ca</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimeHours { get; set; }

        /// <summary>Phụ cấp</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Allowances { get; set; }

        /// <summary>Khoản khấu trừ</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Deductions { get; set; }

        /// <summary>Tổng lương trước thuế (Gross)</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossPay { get; set; }

        /// <summary>Thực lĩnh sau khấu trừ (Net)</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetPay { get; set; }

        // ===== Trạng thái xử lý =====

        /// <summary>Trạng thái lương: Đã tính, Đã duyệt, Đã trả</summary>
        [MaxLength(30)]
        public PayrollStatus Status { get; set; } = PayrollStatus.Calculated;

        /// <summary>Ngày tạo bản ghi</summary>
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;

        /// <summary>Ngày duyệt bản ghi</summary>
        public DateTime? ApprovedDate { get; set; }
    }
}
