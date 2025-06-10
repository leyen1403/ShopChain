using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    public enum ApplicationStatus
    {
        New,
        Interviewed,
        Offered,
        Hired,
        Rejected
    }

    /// <summary>
    /// Đơn ứng tuyển của ứng viên cho một tin tuyển dụng
    /// </summary>
    public class JobApplication
    {
        /// <summary>ID đơn ứng tuyển</summary>
        public int JobApplicationID { get; set; }

        /// <summary>ID tin tuyển dụng</summary>
        public int JobPostingID { get; set; }

        /// <summary>Thông tin tin tuyển dụng</summary>
        public JobPosting JobPosting { get; set; } = null!;

        /// <summary>ID ứng viên</summary>
        public int CandidateID { get; set; }

        /// <summary>Thông tin ứng viên</summary>
        public Candidate Candidate { get; set; } = null!;

        /// <summary>Ngày ứng tuyển</summary>
        public DateTime AppliedDate { get; set; }

        /// <summary>Trạng thái xử lý (vd: New, Interviewed, Offered...)</summary>
        public ApplicationStatus Status { get; set; }

        /// <summary>Ghi chú đánh giá, nhận xét</summary>
        public string Notes { get; set; } = string.Empty;
    }
}
