using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Trạng thái của đơn nghỉ phép
    /// </summary>
    public enum LeaveRequestStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }

    /// <summary>
    /// Đơn nghỉ phép của nhân viên
    /// </summary>
    public class LeaveRequest : AuditableEntity
    {
        /// <summary>ID đơn nghỉ phép</summary>
        public int LeaveRequestID { get; set; }

        /// <summary>ID nhân viên gửi đơn</summary>
        public int EmployeeID { get; set; }

        /// <summary>Thông tin nhân viên gửi đơn</summary>
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; } = null!;

        /// <summary>ID người duyệt</summary>
        public int? ApproverID { get; set; }

        /// <summary>Thông tin người duyệt</summary>
        [ForeignKey("ApproverID")]
        public Employee? Approver { get; set; }

        /// <summary>ID loại nghỉ phép</summary>
        public int LeaveTypeID { get; set; }

        /// <summary>Thông tin loại nghỉ phép</summary>
        [ForeignKey("LeaveTypeID")]
        public LeaveType LeaveType { get; set; } = null!;

        /// <summary>Ngày bắt đầu nghỉ</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Ngày kết thúc nghỉ</summary>
        public DateTime EndDate { get; set; }

        /// <summary>Lý do nghỉ phép</summary>
        public string? Reason { get; set; }

        /// <summary>Trạng thái xử lý đơn</summary>
        public LeaveRequestStatus Status { get; set; } = LeaveRequestStatus.Pending;

        /// <summary>Ngày gửi đơn</summary>
        public DateTime RequestDate { get; set; }

        /// <summary>Ngày phê duyệt/từ chối</summary>
        public DateTime? DecisionDate { get; set; }
    }
}
