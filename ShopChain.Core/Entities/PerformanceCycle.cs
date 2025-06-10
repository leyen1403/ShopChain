using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Phương pháp đánh giá hiệu suất
    /// </summary>
    public enum EvaluationMethod
    {
        KPI,
        OKR,
        _360
    }

    /// <summary>
    /// Chu kỳ đánh giá hiệu suất (theo quý, năm, v.v.)
    /// </summary>
    public class PerformanceCycle : AuditableEntity
    {
        /// <summary>ID chu kỳ</summary>
        [Key]
        public int PerformanceCycleID { get; set; }

        /// <summary>Tên chu kỳ (vd: "Đánh giá Q1-2025")</summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>Ngày bắt đầu chu kỳ</summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>Ngày kết thúc chu kỳ</summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>Phương pháp đánh giá</summary>
        [Required]
        public EvaluationMethod Method { get; set; } = EvaluationMethod.KPI;

        /// <summary>Đang hoạt động?</summary>
        public bool IsActive { get; set; } = true;

        /// <summary>Danh sách đánh giá trong chu kỳ</summary>
        public List<PerformanceReview> Reviews { get; set; } = new();
    }
}
