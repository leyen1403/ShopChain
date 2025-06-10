using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Trạng thái chấm công
    /// </summary>
    public enum AttendanceStatus
    {
        Normal,
        Absent,
        Late,
        PendingCorrection
    }

    /// <summary>
    /// Bản ghi chấm công của nhân viên theo ngày
    /// </summary>
    public class AttendanceRecord : AuditableEntity
    {
        /// <summary>ID bản ghi</summary>
        [Key]
        public int AttendanceRecordID { get; set; }

        /// <summary>ID nhân viên</summary>
        [ForeignKey(nameof(Employee))]
        public int EmployeeID { get; set; }

        /// <summary>Thông tin nhân viên</summary>
        public Employee Employee { get; set; } = null!;

        /// <summary>Ngày làm việc</summary>
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>Giờ vào</summary>
        public DateTime? CheckInTime { get; set; }

        /// <summary>Giờ ra</summary>
        public DateTime? CheckOutTime { get; set; }

        /// <summary>Đi trễ</summary>
        public bool IsLate { get; set; } = false;

        /// <summary>Thiếu giờ ra</summary>
        public bool MissingCheckOut { get; set; } = false;

        /// <summary>Trạng thái chấm công</summary>
        [MaxLength(30)]
        public AttendanceStatus Status { get; set; }

        /// <summary>Ghi chú</summary>
        [MaxLength(500)]
        public string? Notes { get; set; }

        /// <summary>HR đã xác minh</summary>
        public bool Verified { get; set; } = false;
    }
}
