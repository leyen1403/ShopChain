using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Tin đăng tuyển dụng được tạo từ yêu cầu tuyển dụng
    /// </summary>
    public class JobPosting
    {
        /// <summary>ID tin đăng</summary>
        public int JobPostingID { get; set; }

        /// <summary>ID yêu cầu tuyển dụng liên kết</summary>
        public int JobRequestID { get; set; }

        /// <summary>Thông tin yêu cầu tuyển dụng</summary>
        public JobRequest JobRequest { get; set; } = null!;

        /// <summary>Tiêu đề tin tuyển dụng</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Nội dung mô tả công việc</summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>Ngày đăng tin</summary>
        public DateTime PostedDate { get; set; }

        /// <summary>Trạng thái tin đang mở ứng tuyển?</summary>
        public bool IsOpen { get; set; }

        /// <summary>Danh sách đơn ứng tuyển cho tin này</summary>
        public List<JobApplication> Applications { get; set; } = new();
    }
}
