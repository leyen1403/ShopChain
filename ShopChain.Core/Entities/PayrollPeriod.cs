using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Kỳ lương (theo tháng, quý, v.v.)
    /// </summary>
    public class PayrollPeriod : AuditableEntity
    {
        /// <summary>ID kỳ lương</summary>
        [Key]
        public int PayrollPeriodID { get; set; }

        /// <summary>Tên kỳ (vd: "2025-06")</summary>
        [Required]
        [MaxLength(20)]
        public string PeriodName { get; set; } = null!;

        /// <summary>Ngày bắt đầu kỳ lương</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Ngày kết thúc kỳ lương</summary>
        public DateTime EndDate { get; set; }

        /// <summary>Đã chốt lương</summary>
        public bool IsClosed { get; set; } = false;

        /// <summary>Danh sách bản ghi lương thuộc kỳ này</summary>
        public List<PayrollRecord> PayrollRecords { get; set; } = new();
    }
}
