using System.Collections.Generic;

namespace ShopChain.Application.Dtos
{
    /// <summary>
    /// DTO đại diện cho tỉnh/thành phố
    /// </summary>
    public class ProvinceDto
    {
        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Tên mã code dạng chuỗi
        /// </summary>
        public string CodeName { get; set; } = null!;

        /// <summary>
        /// Loại đơn vị hành chính (Tỉnh/Thành phố)
        /// </summary>
        public string DivisionType { get; set; } = null!;

        /// <summary>
        /// Mã vùng điện thoại
        /// </summary>
        public int PhoneCode { get; set; }

        /// <summary>
        /// Danh sách quận/huyện thuộc tỉnh
        /// </summary>
        public List<DistrictDto> Districts { get; set; } = null!;
    }
}
