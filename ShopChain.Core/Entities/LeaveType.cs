namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Loại nghỉ phép (ví dụ: Nghỉ phép năm, Nghỉ bệnh)
    /// </summary>
    public class LeaveType : AuditableEntity
    {
        /// <summary>ID loại nghỉ phép</summary>
        public int LeaveTypeID { get; set; }

        /// <summary>Mã loại (ví dụ: AL, SL...)</summary>
        public string Code { get; set; } = null!;

        /// <summary>Tên loại nghỉ phép</summary>
        public string Name { get; set; } = null!;

        /// <summary>Mô tả chi tiết (tuỳ chọn)</summary>
        public string? Description { get; set; }

        /// <summary>Số ngày nghỉ mặc định</summary>
        public int DefaultDays { get; set; }

        /// <summary>Có tính lương hay không</summary>
        public bool IsPaid { get; set; }

        /// <summary>Đang hoạt động hay không</summary>
        public bool IsActive { get; set; }

        /// <summary>Danh sách đơn nghỉ phép thuộc loại này</summary>
        public List<LeaveRequest> LeaveRequests { get; set; } = new();
    }
}
