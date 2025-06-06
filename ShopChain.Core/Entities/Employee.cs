using System;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Thực thể Nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Mã nhân viên (Primary Key)
        /// </summary>
        [Key]
        public int EmployeeID { get; set; }

        /// <summary>
        /// Họ tên đầy đủ
        /// </summary>
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Email liên hệ
        /// </summary>
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Chức vụ
        /// </summary>
        [MaxLength(50)]
        public string Position { get; set; } = null!;

        /// <summary>
        /// Cờ xóa mềm
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Thời điểm tạo
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Thời điểm cập nhật cuối cùng
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
