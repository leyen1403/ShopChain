using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Thông tin ứng viên ứng tuyển vào các vị trí
    /// </summary>
    public class Candidate
    {
        /// <summary>ID ứng viên</summary>
        public int CandidateID { get; set; }

        /// <summary>Họ tên ứng viên</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Email liên hệ</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>URL tới file CV</summary>
        public string CVFileUrl { get; set; } = string.Empty;

        /// <summary>Danh sách đơn ứng tuyển</summary>
        public List<JobApplication> Applications { get; set; } = new();
    }
}
