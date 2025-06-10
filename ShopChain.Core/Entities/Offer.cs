using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    public enum OfferStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    /// <summary>
    /// Thư mời nhận việc được gửi cho ứng viên sau khi vượt qua vòng phỏng vấn.
    /// </summary>
    public class Offer
    {
        /// <summary>Mã định danh thư mời.</summary>
        public int OfferID { get; set; }

        /// <summary>Mã đơn ứng tuyển liên quan đến thư mời.</summary>
        public int JobApplicationID { get; set; }

        /// <summary>Tham chiếu đến đơn ứng tuyển.</summary>
        public JobApplication JobApplication { get; set; } = null!;

        /// <summary>Mức lương đề xuất cho vị trí ứng tuyển.</summary>
        public decimal ProposedSalary { get; set; }

        /// <summary>Ngày dự kiến bắt đầu làm việc.</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Trạng thái thư mời (Pending, Accepted, Rejected).</summary>
        public OfferStatus Status { get; set; }
    }
}
