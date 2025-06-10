using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Thực thể Nhân viên
    /// </summary>
    public class Employee : AuditableEntity
    {
        /// <summary>Mã nhân viên (Primary Key)</summary>
        [Key]
        public int EmployeeID { get; set; }

        /// <summary>Họ tên đầy đủ</summary>
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        /// <summary>Email liên hệ</summary>
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>Số điện thoại</summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>Chức vụ trong công ty</summary>
        [MaxLength(50)]
        public string Position { get; set; } = null!;

        /// <summary>ID phòng ban</summary>
        public int DepartmentID { get; set; }

        /// <summary>Thông tin phòng ban</summary>
        public Department? Department { get; set; }

        /// <summary>Các yêu cầu nghỉ phép</summary>
        public List<LeaveRequest> LeaveRequests { get; set; } = new();

        /// <summary>Bản ghi chấm công</summary>
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new();

        /// <summary>Bản ghi lương</summary>
        public List<PayrollRecord> PayrollRecords { get; set; } = new();

        /// <summary>Bản đánh giá hiệu suất</summary>
        public List<PerformanceReview> PerformanceReviews { get; set; } = new();

    }
}
