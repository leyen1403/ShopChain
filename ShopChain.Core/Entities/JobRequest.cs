using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Yêu cầu tuyển dụng được gửi từ quản lý/phòng ban
    /// </summary>
    public class JobRequest
    {
        /// <summary>ID yêu cầu tuyển dụng</summary>
        public int JobRequestID { get; set; }

        /// <summary>Vị trí cần tuyển</summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>ID phòng ban</summary>
        public int DepartmentID { get; set; }

        /// <summary>Thông tin phòng ban</summary>
        public Department Department { get; set; } = null!;

        /// <summary>ID người gửi yêu cầu (thường là quản lý)</summary>
        public int RequestedByID { get; set; }

        /// <summary>Thông tin người gửi yêu cầu</summary>
        public Employee RequestedBy { get; set; } = null!;

        /// <summary>Ngày gửi yêu cầu</summary>
        public DateTime RequestDate { get; set; }

        /// <summary>Mô tả chi tiết về yêu cầu tuyển dụng</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>Yêu cầu đã được phê duyệt hay chưa</summary>
        public bool Approved { get; set; }

        /// <summary>ID người phê duyệt (nếu có)</summary>
        public int? ApprovedByID { get; set; }

        /// <summary>Tin tuyển dụng được tạo từ yêu cầu này (nếu có)</summary>
        public JobPosting? JobPosting { get; set; }
    }
}

