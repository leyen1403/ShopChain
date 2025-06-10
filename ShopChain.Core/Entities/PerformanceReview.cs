using System;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Trạng thái của bản đánh giá hiệu suất
    /// </summary>
    public enum ReviewStatus
    {
        NotStarted,
        SelfDone,
        ManagerDone,
        Finalized
    }

    /// <summary>
    /// Đánh giá hiệu suất của một nhân viên trong một chu kỳ
    /// </summary>
    public class PerformanceReview : AuditableEntity
    {
        /// <summary>ID đánh giá</summary>
        [Key]
        public int PerformanceReviewID { get; set; }

        /// <summary>ID chu kỳ đánh giá</summary>
        [Required]
        public int PerformanceCycleID { get; set; }

        /// <summary>Thông tin chu kỳ đánh giá</summary>
        public PerformanceCycle PerformanceCycle { get; set; } = null!;

        /// <summary>ID nhân viên được đánh giá</summary>
        [Required]
        public int EmployeeID { get; set; }

        /// <summary>Thông tin nhân viên</summary>
        public Employee Employee { get; set; } = null!;

        /// <summary>ID người quản lý đánh giá</summary>
        public int? ManagerID { get; set; }

        /// <summary>Thông tin người quản lý</summary>
        public Employee? Manager { get; set; }

        /// <summary>Tự đánh giá của nhân viên</summary>
        [MaxLength(2000)]
        public string? SelfEvaluation { get; set; }

        /// <summary>Đánh giá của quản lý</summary>
        [MaxLength(2000)]
        public string? ManagerEvaluation { get; set; }

        /// <summary>Điểm tự đánh giá</summary>
        [Range(0, 10)]
        public decimal? SelfScore { get; set; }

        /// <summary>Điểm do quản lý đánh giá</summary>
        [Range(0, 10)]
        public decimal? ManagerScore { get; set; }

        /// <summary>Điểm tổng kết</summary>
        [Range(0, 10)]
        public decimal? FinalScore { get; set; }

        /// <summary>Xếp loại tổng kết (ví dụ: Excellent, Good)</summary>
        [MaxLength(50)]
        public string? FinalRating { get; set; }

        /// <summary>Trạng thái đánh giá</summary>
        [Required]
        public ReviewStatus Status { get; set; }

        /// <summary>Ngày nhân viên nộp đánh giá</summary>
        public DateTime? SubmittedDate { get; set; }

        /// <summary>Ngày quản lý hoàn tất đánh giá</summary>
        public DateTime? ManagerReviewedDate { get; set; }

        /// <summary>Ngày hoàn tất đánh giá cuối cùng</summary>
        public DateTime? FinalizedDate { get; set; }
    }
}
