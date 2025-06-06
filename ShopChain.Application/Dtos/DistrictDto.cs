using System.Collections.Generic;

namespace ShopChain.Application.Dtos
{
    /// <summary>
    /// DTO đại diện cho Quận/Huyện
    /// </summary>
    public class DistrictDto
    {
        /// <summary>
        /// Tên quận/huyện
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mã code dạng chuỗi (codeName)
        /// </summary>
        public string CodeName { get; set; } = null!;

        /// <summary>
        /// Kiểu phân chia hành chính (thị xã, huyện,...)
        /// </summary>
        public string DivisionType { get; set; } = null!;

        /// <summary>
        /// Mã viết tắt ngắn gọn
        /// </summary>
        public string ShortCodeName { get; set; } = null!;

        /// <summary>
        /// Danh sách phường/xã thuộc quận/huyện
        /// </summary>
        public List<WardDto> Wards { get; set; } = null!;
    }
}
